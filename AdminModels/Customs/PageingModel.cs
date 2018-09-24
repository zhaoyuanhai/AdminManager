using System;
using System.Collections.Generic;

namespace AdminModels.Customs
{
    public class PageingModel<T> : IPageingModel<T> where T : class
    {
        public PageingModel()
            : this(1, 10)
        { }

        public PageingModel(int pageIndex, int pageSize)
            : this(pageIndex, pageSize, 0, new List<T>())
        {
        }

        public PageingModel(int pageIndex, int pageSize, int total, IEnumerable<T> datas)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Total = total;
            this.Datas = datas;
        }

        /// <summary>
        /// 数据
        /// </summary>
        public virtual IEnumerable<T> Datas { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public virtual int Total { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 页记录数
        /// </summary>
        public virtual int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public virtual int PageCount
        {
            get
            {
                return (int)Math.Ceiling(this.Total * 1.0 / this.PageSize);
            }
        }
    }

    public class PageingModel : PageingModel<object>
    {
    }
}