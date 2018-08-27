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
            //���Ȩ����������
            if (!context.AuthorityTypes.Any())
            {
                context.AuthorityTypes.AddOrUpdate(
                    new T_AuthorityType()
                    {
                        Id = 1,
                        Description = "�˵�����"
                    }, new T_AuthorityType()
                    {
                        Id = 2,
                        Description = "ҳ��Ԫ������"
                    }, new T_AuthorityType()
                    {
                        Id = 3,
                        Description = "�ļ�����"
                    });
            }

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
                        Icon = "el-icon-document",
                        Url = "/System/MenuManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "�û�����",
                        Icon = "el-icon-document",
                        Url = "/System/UserManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "Ȩ�޹���",
                        Icon = "el-icon-document",
                        Url = "/System/AuthorityManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "��ɫ����",
                        Icon = "el-icon-document",
                        Url = "/System/RoleManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "�û������",
                        Icon = "el-icon-document",
                        Url = "/System/UserGroupManager"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "������־",
                        Icon = "el-icon-document",
                        Url = "/System/OperationLog"
                    },
                    new T_Menu()
                    {
                        ParentId = systemMenu.Id,
                        ParentMenu = systemMenu,
                        Title = "ϵͳ����",
                        Icon = "el-icon-edit",
                        Url = "/System/Config"
                    });
                context.SaveChanges();
            }

            //���Ĭ�Ͻ�ɫ
            if (!context.Roles.Any())
            {
                var user = context.Users.First(x => x.UserName == "root");
                var role = new T_Role()
                {
                    Name = "��������Ա",
                    Description = "ϵͳ�ĳ����û�,ӵ���������ϵ�Ȩ��",
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
