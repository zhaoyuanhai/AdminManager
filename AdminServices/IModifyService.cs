using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AdminServices
{
    public interface IModifyService<T> where T : class, new()
    {
        /// <summary>
        /// 修改对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify(T model);

        /// <summary>
        /// 修改对象的指定字段
        /// </summary>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        int ModifyToFiled(T model, Expression<Func<T, object>> expression);

        /// <summary>
        /// 修改对象,排除指定的字段
        /// </summary>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        int ModifyExcludeField(T model, Expression<Func<T, object>> expression);

        /// <summary>
        /// 修改一个集合
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        int ModifyBatch(IEnumerable<T> models);
    }
}
