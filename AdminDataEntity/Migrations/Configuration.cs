namespace AdminDataEntity.Migrations
{
    using AdminModels.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdminDataEntity.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AdminDataEntity.DataEntities";
        }

        protected override void Seed(AdminDataEntity.DataEntities context)
        {
            //添加初始用户
            if (!context.Users.Any(x => x.UserName == "root"))
            {
                context.Users.Add(new T_User()
                {
                    UserName = "root",
                    Password = "123456",
                    RealName = "超级管理员"
                });
            }

            //创建初始菜单
            if (!context.Menus.Any(x => x.Title == "系统设置"))
            {
                var systemMenu = new T_Menu()
                {
                    Title = "系统设置",
                    Icon = "el-icon-setting",
                    Url = ""
                };
                context.SaveChanges();
                context.Menus.AddOrUpdate(
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "菜单管理",
                        Url = "/System/MenuManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "用户管理",
                        Url = "/System/UserManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "权限管理",
                        Url = "/System/AuthorityManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "角色管理",
                        Url = "/System/RoleManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "用户组管理",
                        Url = "/System/UserGroupManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "操作日志",
                        Url = "/System/OperationLog"
                    });
                context.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
