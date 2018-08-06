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
    public class MenuService : BaseService<T_Menu>, IMenuService, ITable<T_Menu>
    {
        public DbSet<T_Menu> Table => entities.Menus;


    }
}
