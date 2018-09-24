using AdminModels;
using AdminModels.Entities;
using AdminServices.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServicesRealization.System
{
    public class EntityService<T> : BaseService<T>, IEntityService<T>
        where T : ModelBase, new()
    {
        public IEnumerable<T_TableColumn> GetTableColumnsByTableName(string tableName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T_TableColumn> GetTableColumnsByTableType(Type tableType)
        {
            throw new NotImplementedException();
        }
    }
}
