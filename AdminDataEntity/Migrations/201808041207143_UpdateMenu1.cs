namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenu1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Menu", "ParentId", c => c.Int());
            CreateIndex("dbo.T_Menu", "ParentId");
            AddForeignKey("dbo.T_Menu", "ParentId", "dbo.T_Menu", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Menu", "ParentId", "dbo.T_Menu");
            DropIndex("dbo.T_Menu", new[] { "ParentId" });
            AlterColumn("dbo.T_Menu", "ParentId", c => c.Int(nullable: false));
        }
    }
}
