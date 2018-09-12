using AdminModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices.System
{
    public interface IOperationService : IAddService<T_Operation>, IModifyService<T_Operation>, ISelectService<T_Operation>, IDeleteService<T_Operation>
    {

    }
}
