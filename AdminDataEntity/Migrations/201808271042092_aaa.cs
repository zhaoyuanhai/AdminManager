namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.T_Authority", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.T_Authority", "Name", unique: true);
        }
    }
}
