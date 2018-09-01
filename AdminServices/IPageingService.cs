using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices
{
    public interface IPageingModel<T> where T : class
    {
        /// <summary>
        /// 数据
        /// </summary>
        IEnumerable<T> Datas { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount { get; }
    }
}
