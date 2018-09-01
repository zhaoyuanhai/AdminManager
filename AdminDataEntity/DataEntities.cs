using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModels.Entities;
using System.Data.SqlClient;
using AdminDataEntity.Models;
using System.Reflection;

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
            this.Configuration.LazyLoadingEnabled = true;

            #region 设置外键关联关系
            //用户和角色
            modelBuilder.Entity<T_User>()
                .HasMany(x => x.Roles)
                .WithMany(e => e.Users).Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("T_UserRole");
                });

            //用户和组
            modelBuilder.Entity<T_User>()
                .HasMany(x => x.Groups)
                .WithMany(x => x.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("GroupId");
                    m.ToTable("T_UserGroup");
                });

            //角色和组
            modelBuilder.Entity<T_Role>()
                .HasMany(x => x.Groups)
                .WithMany(x => x.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("GroupId");
                    m.ToTable("T_RoleGroup");
                });

            //角色和权限
            modelBuilder.Entity<T_Role>()
                .HasMany(x => x.Authorities)
                .WithMany(x => x.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("AuthorityId");
                    m.ToTable("T_RoleAuthority");
                });

            //权限和菜单
            modelBuilder.Entity<T_Authority>()
                .HasMany(x => x.Menus)
                .WithMany(x => x.Authorities)
                .Map(m =>
                {
                    m.MapLeftKey("AuthorityId");
                    m.MapRightKey("MenuId");
                    m.ToTable("T_AuthorityMenu");
                });

            //权限和功能
            modelBuilder.Entity<T_Authority>()
                .HasMany(x => x.Operations)
                .WithMany(x => x.Authorities)
                .Map(m =>
                {
                    m.MapLeftKey("AuthorityId");
                    m.MapRightKey("OperationId");
                    m.ToTable("T_AuthorityOperation");
                });

            //菜单和功能
            modelBuilder.Entity<T_Menu>()
                .HasMany(x => x.Operations)
                .WithMany(x => x.Menus)
                .Map(m =>
                {
                    m.MapLeftKey("MenuId");
                    m.MapRightKey("OperationId");
                    m.ToTable("T_MenuOperation");
                });
            #endregion

            #region 设置约束
            modelBuilder.Entity<T_User>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<T_Role>().HasIndex(x => x.Name).IsUnique();
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="T">返回的数据对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameter">参数对象,以属性名称对应</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcdure<T>(string procName, object parameter = null)
        {
            var ps = this.Database.SqlQuery<ParameterModel>($@"
                SELECT id,isoutparam,name,length
                    FROM dbo.syscolumns
                    WHERE id IN (SELECT id
                                    FROM sysobjects AS a
                                    WHERE OBJECTPROPERTY(id, N'IsProcedure') = 1
                                          AND id = OBJECT_ID(N'[dbo].[{procName}]')
                                );").ToList();

            var objPs = parameter == null ? new PropertyInfo[0] : parameter.GetType().GetProperties();
            SqlParameter[] sqlps = ps
                .Where(p => objPs.FirstOrDefault(x => $"@{x.Name}".Equals(p.Name, StringComparison.CurrentCultureIgnoreCase)) != null)
                .Select(p =>
            {
                var pp = objPs.FirstOrDefault(x => $"@{x.Name}".Equals(p.Name, StringComparison.CurrentCultureIgnoreCase));

                return new SqlParameter()
                {
                    ParameterName = p.Name,
                    Value = pp.GetValue(parameter),
                    Direction = p.IsOutParam == 1 ? ParameterDirection.Output : ParameterDirection.Input,
                    Size = p.Length
                };

            }).ToArray();

            string strps = string.Join(",", sqlps.Select(x => x.Direction == ParameterDirection.Output ? $"{x.ParameterName} output" : x.ParameterName));

            var data = this.Database.SqlQuery<T>($"EXEC {procName} {strps};", sqlps).ToList();
            foreach (var item in sqlps)
            {
                if (item.Direction == ParameterDirection.Output)
                {
                    var p = objPs.FirstOrDefault(x => x.Name.Equals(item.ParameterName.Substring(1), StringComparison.CurrentCultureIgnoreCase));
                    if (p != null)
                    {
                        p.SetValue(parameter, item.Value);
                    }
                }
            }

            return data;
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

        /// <summary>
        /// 权限类型表
        /// </summary>
        public DbSet<T_AuthorityType> AuthorityTypes { get; set; }
    }
}
