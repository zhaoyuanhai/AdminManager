using System;
using System.Linq.Expressions;

namespace AdminModels.Customs
{
    /// <summary>
    /// 条件对象接口
    /// </summary>
    public interface IExpressionLambdaModel
    {
        Expression<Func<T, bool>> ToExpression<T>() where T : class;
    }
}