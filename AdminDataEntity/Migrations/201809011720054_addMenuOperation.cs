namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMenuOperation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_MenuOperation",
                c => new
                    {
                        MenuId = c.Int(nullable: false),
                        OperationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuId, t.OperationId })
                .ForeignKey("dbo.T_Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.T_Operation", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.OperationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_MenuOperation", "OperationId", "dbo.T_Operation");
            DropForeignKey("dbo.T_MenuOperation", "MenuId", "dbo.T_Menu");
            DropIndex("dbo.T_MenuOperation", new[] { "OperationId" });
            DropIndex("dbo.T_MenuOperation", new[] { "MenuId" });
            DropTable("dbo.T_MenuOperation");
        }
    }
}
