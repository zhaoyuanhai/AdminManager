namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Authority",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ParentId = c.Int(),
                        Icon = c.String(),
                        Order = c.Int(nullable: false),
                        Url = c.String(),
                        AuthorityId = c.Int(nullable: false),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.T_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        AuthorityId = c.Int(nullable: false),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        Description = c.String(),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Group", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.T_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RealName = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        LoginCount = c.Long(nullable: false),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_OperatorLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        GenDate = c.DateTime(nullable: false),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.T_AuthorityMenu",
                c => new
                    {
                        AuthorityId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorityId, t.MenuId })
                .ForeignKey("dbo.T_Authority", t => t.AuthorityId, cascadeDelete: true)
                .ForeignKey("dbo.T_Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.AuthorityId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.T_RoleAuthority",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        AuthorityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.AuthorityId })
                .ForeignKey("dbo.T_Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.T_Authority", t => t.AuthorityId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.AuthorityId);
            
            CreateTable(
                "dbo.T_UserGroup",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.T_User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.T_Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.T_UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.T_User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.T_Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.T_RoleGroup",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.GroupId })
                .ForeignKey("dbo.T_Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.T_Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_OperatorLog", "UserId", "dbo.T_User");
            DropForeignKey("dbo.T_RoleGroup", "GroupId", "dbo.T_Group");
            DropForeignKey("dbo.T_RoleGroup", "RoleId", "dbo.T_Role");
            DropForeignKey("dbo.T_UserRole", "RoleId", "dbo.T_Role");
            DropForeignKey("dbo.T_UserRole", "UserId", "dbo.T_User");
            DropForeignKey("dbo.T_UserGroup", "GroupId", "dbo.T_Group");
            DropForeignKey("dbo.T_UserGroup", "UserId", "dbo.T_User");
            DropForeignKey("dbo.T_Group", "ParentId", "dbo.T_Group");
            DropForeignKey("dbo.T_RoleAuthority", "AuthorityId", "dbo.T_Authority");
            DropForeignKey("dbo.T_RoleAuthority", "RoleId", "dbo.T_Role");
            DropForeignKey("dbo.T_AuthorityMenu", "MenuId", "dbo.T_Menu");
            DropForeignKey("dbo.T_AuthorityMenu", "AuthorityId", "dbo.T_Authority");
            DropForeignKey("dbo.T_Menu", "ParentId", "dbo.T_Menu");
            DropIndex("dbo.T_RoleGroup", new[] { "GroupId" });
            DropIndex("dbo.T_RoleGroup", new[] { "RoleId" });
            DropIndex("dbo.T_UserRole", new[] { "RoleId" });
            DropIndex("dbo.T_UserRole", new[] { "UserId" });
            DropIndex("dbo.T_UserGroup", new[] { "GroupId" });
            DropIndex("dbo.T_UserGroup", new[] { "UserId" });
            DropIndex("dbo.T_RoleAuthority", new[] { "AuthorityId" });
            DropIndex("dbo.T_RoleAuthority", new[] { "RoleId" });
            DropIndex("dbo.T_AuthorityMenu", new[] { "MenuId" });
            DropIndex("dbo.T_AuthorityMenu", new[] { "AuthorityId" });
            DropIndex("dbo.T_OperatorLog", new[] { "UserId" });
            DropIndex("dbo.T_Group", new[] { "ParentId" });
            DropIndex("dbo.T_Menu", new[] { "ParentId" });
            DropTable("dbo.T_RoleGroup");
            DropTable("dbo.T_UserRole");
            DropTable("dbo.T_UserGroup");
            DropTable("dbo.T_RoleAuthority");
            DropTable("dbo.T_AuthorityMenu");
            DropTable("dbo.T_OperatorLog");
            DropTable("dbo.T_User");
            DropTable("dbo.T_Group");
            DropTable("dbo.T_Role");
            DropTable("dbo.T_Menu");
            DropTable("dbo.T_Authority");
        }
    }
}
