using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AdminServices
{
    public interface ISelectService<T> where T : class, new()
    {
        /// <summary>
        /// 根据主键查找对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(params object[] keyValues);

        IEnumerable<T> Select();

        IEnumerable<T> Select(Expression<Func<T, bool>> expression);

        Tuple<IEnumerable<T>, int> SelectPage(int pageIndex, int pageSize);

        Tuple<IEnumerable<T>, int> SelectPage(Expression<Func<T, bool>> expression, int pageIndex, int pageSize);
    }
}
