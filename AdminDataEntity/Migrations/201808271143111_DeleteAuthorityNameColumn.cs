namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAuthorityNameColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_Authority", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Authority", "Name", c => c.String(maxLength: 20));
        }
    }
}
