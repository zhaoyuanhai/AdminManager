namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Authority", "_UpdateDate", c => c.DateTime());
            AlterColumn("dbo.T_Role", "_UpdateDate", c => c.DateTime());
            AlterColumn("dbo.T_User", "_UpdateDate", c => c.DateTime());
            AlterColumn("dbo.T_Group", "_UpdateDate", c => c.DateTime());
            AlterColumn("dbo.T_Menu", "_UpdateDate", c => c.DateTime());
            AlterColumn("dbo.T_OperatorLog", "_UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_OperatorLog", "_UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_Menu", "_UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_Group", "_UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_User", "_UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_Role", "_UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_Authority", "_UpdateDate", c => c.DateTime(nullable: false));
        }
    }
}
