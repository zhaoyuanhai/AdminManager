namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addconstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Authority", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.T_Menu", "Title", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.T_Menu", "Icon", c => c.String(maxLength: 20));
            AlterColumn("dbo.T_Role", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.T_User", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.T_User", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.T_User", "RealName", c => c.String(maxLength: 20));
            AlterColumn("dbo.T_User", "Mobile", c => c.String(maxLength: 11));
            AlterColumn("dbo.T_User", "Email", c => c.String(maxLength: 50));
            CreateIndex("dbo.T_Authority", "Name", unique: true);
            CreateIndex("dbo.T_Role", "Name", unique: true);
            CreateIndex("dbo.T_User", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.T_User", new[] { "UserName" });
            DropIndex("dbo.T_Role", new[] { "Name" });
            DropIndex("dbo.T_Authority", new[] { "Name" });
            AlterColumn("dbo.T_User", "Email", c => c.String());
            AlterColumn("dbo.T_User", "Mobile", c => c.String());
            AlterColumn("dbo.T_User", "RealName", c => c.String());
            AlterColumn("dbo.T_User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.T_User", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.T_Role", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.T_Menu", "Icon", c => c.String());
            AlterColumn("dbo.T_Menu", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.T_Authority", "Name", c => c.String());
        }
    }
}
