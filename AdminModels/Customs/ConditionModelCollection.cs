using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminModels.Customs
{
    /// <summary>
    /// 组织条件对象，与或的关系
    /// </summary>
    public class ConditionModelCollection : List<ConditionModel>, IEnumerable<ConditionModel>, IExpressionLambdaModel
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Expression<Func<T, bool>> ToExpression<T>() where T : class
        {
            this.Sort();
            var prop = Expression.Parameter(typeof(T), "it");
            Expression<Func<T, bool>> lambdaExp = null;
            foreach (var group in this.GroupBy(x => x.Group))
            {
                foreach (var item in group)
                {
                    item.PropExpression = prop;
                    var exp = item.ToExpression<T>();
                    if (lambdaExp == null)
                    {
                        lambdaExp = exp;
                        continue;
                    }

                    lambdaExp = Expression.Lambda<Func<T, bool>>(Expression.And(lambdaExp.Body, exp.Body), exp.Parameters);
                }
            }
            return lambdaExp;
        }
    }
}