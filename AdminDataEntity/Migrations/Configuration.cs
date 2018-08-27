namespace AdminDataEntity.Migrations
{
    using AdminModels.Entities;
    using System;
    using System.Configuration;
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

        protected override void Seed(DataEntities context)
        {
            //添加权限类型数据
            if (!context.AuthorityTypes.Any())
            {
                context.AuthorityTypes.AddOrUpdate(
                    new T_AuthorityType()
                    {
                        Id = 1,
                        Description = "菜单类型"
                    }, new T_AuthorityType()
                    {
                        Id = 2,
                        Description = "页面元素类型"
                    }, new T_AuthorityType()
                    {
                        Id = 3,
                        Description = "文件类型"
                    });
            }

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
                        Icon = "el-icon-document",
                        Url = "/System/MenuManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "用户管理",
                        Icon = "el-icon-document",
                        Url = "/System/UserManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "权限管理",
                        Icon = "el-icon-document",
                        Url = "/System/AuthorityManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "角色管理",
                        Icon = "el-icon-document",
                        Url = "/System/RoleManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "用户组管理",
                        Icon = "el-icon-document",
                        Url = "/System/UserGroupManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "操作日志",
                        Icon = "el-icon-document",
                        Url = "/System/OperationLog"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "系统配置",
                        Icon = "el-icon-edit",
                        Url = "/System/Config"
                    });
                context.SaveChanges();
            }

            //添加默认角色
            if (!context.Roles.Any())
            {
                var user = context.Users.First(x => x.UserName == "root");
                var role = new T_Role()
                {
                    Name = "超级管理员",
                    Description = "系统的超级用户,拥有至高无上的权利",
                };
                role.Users.Add(user);
                context.Roles.AddOrUpdate(role);
                context.SaveChanges();
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
