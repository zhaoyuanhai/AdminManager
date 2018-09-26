using AdminModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices.System
{
    public interface IUserGroupService : IAddService<T_Group>, IModifyService<T_Group>, ISelectService<T_Group>, IDeleteService<T_Group>
    {
    }
}
