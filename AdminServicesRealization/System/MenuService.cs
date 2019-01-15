using AdminModels.Entities;
using AdminServices.System;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminCommon;

namespace AdminServicesRealization.System
{
    public class MenuService : BaseService<T_Menu>, IMenuService, ITable<T_Menu>
    {
        public DbSet<T_Menu> Table => entities.Menus;

        public IEnumerable<T_Menu> GetMenusByUserId(int userId)
        {
            return entities.ExecProcdure<T_Menu>("P_GetMenuByUserId", new { userId });
        }

        public IEnumerable<T_Operation> GetOperationsByMenuId(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveMenuOperation(int menuId, int[] operations)
        {
            var menu = entities.Menus.Find(menuId);
            var ops = entities.Operations.Where(op => operations.Contains(op.Id)).ToList();

            if (menu.Operations != null)
            {
                menu.Operations.RemoveRange(menu.Operations.Except(ops));
                menu.Operations.AddRange(ops.Except(menu.Operations));
            }
            else
            {
                menu.Operations.AddRange(ops);
            }
            entities.SaveChanges();
            return true;
        }
    }
}
