using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IEntityService<T> : ISelectService<T>, IDeleteService<T>, IModifyService<T>, IAddService<T>
        where T : class, new()
    {
        /// <summary>
        /// 获取表的列
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <returns></returns>
        IEnumerable<T_TableColumn> GetTableColumnsByTableName(string tableName);

        /// <summary>
        /// 获取表的列
        /// </summary>
        /// <param name="tableName">表类型</param>
        /// <returns></returns>
        IEnumerable<T_TableColumn> GetTableColumnsByTableType(Type tableType);
    }
}
