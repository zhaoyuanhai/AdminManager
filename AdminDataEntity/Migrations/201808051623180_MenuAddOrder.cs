namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuAddOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Menu", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Menu", "Order");
        }
    }
}
