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
        public DataEntities()
            : base("name=adminEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 菜单表
        /// </summary>
        public DbSet<T_Menu> Menus { get; set; }

        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<T_User> Users { get; set; }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<T_Role> Roles { get; set; }

        /// <summary>
        /// 组表
        /// </summary>
        public DbSet<T_Group> Groups { get; set; }

        /// <summary>
        /// 权限表
        /// </summary>
        public DbSet<T_Authority> Authorities { get; set; }

        /// <summary>
        /// 操作日期表
        /// </summary>
        public DbSet<T_OperatorLog> OperatorLogs { get; set; }
    }
}
