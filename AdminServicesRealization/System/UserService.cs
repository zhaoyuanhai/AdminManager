using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdminModels;
using AdminModels.Entities;
using AdminServices.System;

namespace AdminServicesRealization.System
{
    public class UserService : BaseService<T_User>, IUserService, ITable<T_User>
    {
        DbSet<T_User> ITable<T_User>.Table => entities.Users;
    }
}
