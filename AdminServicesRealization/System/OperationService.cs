using AdminModels.Entities;
using AdminServices.System;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServicesRealization.System
{
    public class OperationService : BaseService<T_Operation>, IOperationService, ITable<T_Operation>
    {
        public DbSet<T_Operation> Table => entities.Operations;
    }
}
