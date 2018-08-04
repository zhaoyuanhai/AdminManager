using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModels.Entities;

namespace AdminDataEntity
{
    public class DataEntities : DbContext
    {
        public DbSet<T_Menu> Menus { get; set; }
    }
}
