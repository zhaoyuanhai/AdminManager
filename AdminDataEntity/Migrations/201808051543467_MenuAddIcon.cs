namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuAddIcon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Menu", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Menu", "Icon");
        }
    }
}
