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
            context.Users.AddOrUpdate(new T_User()
            {
                UserName = "root",
                Password = "123456",
                RealName = "超级管理员"
            });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
