namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_Authority", "RoleId");
            DropColumn("dbo.T_Authority", "MenuId");
            DropColumn("dbo.T_Menu", "AuthorityId");
            DropColumn("dbo.T_Role", "UserId");
            DropColumn("dbo.T_Role", "GroupId");
            DropColumn("dbo.T_Role", "AuthorityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Role", "AuthorityId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Role", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Role", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Menu", "AuthorityId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Authority", "MenuId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Authority", "RoleId", c => c.Int(nullable: false));
        }
    }
}
