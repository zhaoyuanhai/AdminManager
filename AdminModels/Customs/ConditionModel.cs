using System;
using System.Linq;
using System.Linq.Expressions;

namespace AdminModels.Customs
{
    /// <summary>
    /// 条件模型，将对象组织成lambda表达式
    /// </summary>
    public class ConditionModel : IComparable<ConditionModel>, IExpressionLambdaModel
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public Operation Op { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; } = "";

        internal ParameterExpression PropExpression { get; set; }

        /// <summary>
        /// 按照分组名称排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        int IComparable<ConditionModel>.CompareTo(ConditionModel other)
        {
            return this.Group.CompareTo(other.Group);
        }

        public Expression<Func<T, bool>> ToExpression<T>() where T : class
        {
            Expression body = null;
            var parameter = PropExpression ?? Expression.Parameter(typeof(T), "it");
            var prop = Expression.Property(parameter, this.Field);
            var propType = typeof(T).GetProperty(this.Field).PropertyType;
            ConstantExpression value = null;

            var strContainsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            var containsMethod = typeof(Enumerable).GetMethods().First(x => x.Name == "Contains" && x.IsGenericMethod && x.GetParameters().Length == 2);

            if (this.Value is string || this.Value is int || this.Value is double || this.Value is DateTime)
                value = Expression.Constant(Convert.ChangeType(this.Value, propType));
            else
                value = Expression.Constant(this.Value);
            switch (this.Op)
            {
                case Operation.equal:
                    body = Expression.Equal(prop, value);
                    break;

                case Operation.notequal:
                    body = Expression.NotEqual(prop, value);
                    break;

                case Operation.greaterthan:
                    body = Expression.GreaterThan(prop, value);
                    break;

                case Operation.lessthan:
                    body = Expression.LessThan(prop, value);
                    break;

                case Operation.gtequal:
                    body = Expression.GreaterThanOrEqual(prop, value);
                    break;

                case Operation.ltequal:
                    body = Expression.LessThanOrEqual(prop, value);
                    break;

                case Operation.between:
                    if (!(this.Value is Array))
                        throw new TypeUnloadedException("类型只能为 数组");
                    var arr = this.Value as Array;

                    if (arr.Length != 2)
                        throw new Exception("数组的长度只能为2");

                    var value1 = Expression.Constant(arr.GetValue(0), propType);
                    var value2 = Expression.Constant(arr.GetValue(1), propType);

                    body = Expression.And(Expression.GreaterThan(prop, value1),
                        Expression.LessThan(prop, value2));
                    break;

                case Operation.contain:
                    if (this.Value is string)
                    {
                        //body = Expression.Call(prop, strContainsMethod, value);
                        body = Expression.Call(prop, "Contains", Type.EmptyTypes, value);
                    }
                    else if (this.Value is Array)
                    {
                        body = Expression.Call(typeof(Enumerable), "Contains", new Type[] { propType }, value, prop);
                    }
                    else
                        throw new TypeUnloadedException("类型只能为 String 或者 Array");
                    break;
            }
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    public enum Operation
    {
        /// <summary>
        /// 等于
        /// </summary>
        equal,

        /// <summary>
        /// 不等于
        /// </summary>
        notequal,

        /// <summary>
        /// 大于
        /// </summary>
        greaterthan,

        /// <summary>
        /// 小于
        /// </summary>
        lessthan,

        /// <summary>
        /// 大于等于
        /// </summary>
        gtequal,

        /// <summary>
        /// 小于等于
        /// </summary>
        ltequal,

        /// <summary>
        /// 在一个范围之间
        /// </summary>
        between,

        /// <summary>
        /// 包含
        /// </summary>
        contain
    }
}