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
        public DbSet<T_User> Table => entities.Users;

        public bool Login(string userName, string password)
        {
            var user = Table.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (user != null)
            {
                user.LoginCount++;
                entities.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SetUserRoles(int userId, int[] roleIds)
        {
            var user = entities.Users.Find(userId);
            user.Roles.Clear();
            entities.Roles.Where(x => roleIds.Contains(x.Id))
                .ToList().ForEach(user.Roles.Add);
            entities.SaveChanges();
            return true;
        }
    }
}
