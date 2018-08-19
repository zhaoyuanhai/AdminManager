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
            //��ӳ�ʼ�û�
            if (!context.Users.Any(x => x.UserName == "root"))
            {
                context.Users.Add(new T_User()
                {
                    UserName = "root",
                    Password = "123456",
                    RealName = "��������Ա"
                });
            }

            //������ʼ�˵�
            if (!context.Menus.Any(x => x.Title == "ϵͳ����"))
            {
                var systemMenu = new T_Menu()
                {
                    Title = "ϵͳ����",
                    Icon = "el-icon-setting",
                    Url = ""
                };
                context.SaveChanges();
                context.Menus.AddOrUpdate(
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "�˵�����",
                        Url = "/System/MenuManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "�û�����",
                        Url = "/System/UserManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "Ȩ�޹���",
                        Url = "/System/AuthorityManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "��ɫ����",
                        Url = "/System/RoleManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "�û������",
                        Url = "/System/UserGroupManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "������־",
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
