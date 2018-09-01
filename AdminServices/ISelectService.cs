﻿using System;
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

        /// <summary>
        /// 查询所有的数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Select();

        /// <summary>
        /// 查询匹配条件的所有数据
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> Select(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns>数据和总条数</returns>
        IPageingModel<T> SelectPage(int pageIndex, int pageSize);

        /// <summary>
        /// 条件分页查询数据
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns>数据和总条数</returns>
        IPageingModel<T> SelectPage(Expression<Func<T, bool>> expression, int pageIndex, int pageSize);
    }
}
