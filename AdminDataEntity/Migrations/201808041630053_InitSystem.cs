namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitSystem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Authority",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(nullable: false),
                        T_Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Authority", t => t.ParentId)
                .ForeignKey("dbo.T_Group", t => t.T_Group_Id)
                .Index(t => t.ParentId)
                .Index(t => t.T_Group_Id);
            
            CreateTable(
                "dbo.T_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        Description = c.String(),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(nullable: false),
                        T_Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Role", t => t.ParentId)
                .ForeignKey("dbo.T_Group", t => t.T_Group_Id)
                .Index(t => t.ParentId)
                .Index(t => t.T_Group_Id);
            
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
                        _UpdateDate = c.DateTime(nullable: false),
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
                        _UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Group", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.T_OperatorLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        GenDate = c.DateTime(nullable: false),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.T_RoleT_Authority",
                c => new
                    {
                        T_Role_Id = c.Int(nullable: false),
                        T_Authority_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.T_Role_Id, t.T_Authority_Id })
                .ForeignKey("dbo.T_Role", t => t.T_Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.T_Authority", t => t.T_Authority_Id, cascadeDelete: true)
                .Index(t => t.T_Role_Id)
                .Index(t => t.T_Authority_Id);
            
            CreateTable(
                "dbo.T_UserT_Authority",
                c => new
                    {
                        T_User_Id = c.Int(nullable: false),
                        T_Authority_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.T_User_Id, t.T_Authority_Id })
                .ForeignKey("dbo.T_User", t => t.T_User_Id, cascadeDelete: true)
                .ForeignKey("dbo.T_Authority", t => t.T_Authority_Id, cascadeDelete: true)
                .Index(t => t.T_User_Id)
                .Index(t => t.T_Authority_Id);
            
            CreateTable(
                "dbo.T_GroupT_User",
                c => new
                    {
                        T_Group_Id = c.Int(nullable: false),
                        T_User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.T_Group_Id, t.T_User_Id })
                .ForeignKey("dbo.T_Group", t => t.T_Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.T_User", t => t.T_User_Id, cascadeDelete: true)
                .Index(t => t.T_Group_Id)
                .Index(t => t.T_User_Id);
            
            CreateTable(
                "dbo.T_UserT_Role",
                c => new
                    {
                        T_User_Id = c.Int(nullable: false),
                        T_Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.T_User_Id, t.T_Role_Id })
                .ForeignKey("dbo.T_User", t => t.T_User_Id, cascadeDelete: true)
                .ForeignKey("dbo.T_Role", t => t.T_Role_Id, cascadeDelete: true)
                .Index(t => t.T_User_Id)
                .Index(t => t.T_Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_OperatorLog", "UserId", "dbo.T_User");
            DropForeignKey("dbo.T_UserT_Role", "T_Role_Id", "dbo.T_Role");
            DropForeignKey("dbo.T_UserT_Role", "T_User_Id", "dbo.T_User");
            DropForeignKey("dbo.T_GroupT_User", "T_User_Id", "dbo.T_User");
            DropForeignKey("dbo.T_GroupT_User", "T_Group_Id", "dbo.T_Group");
            DropForeignKey("dbo.T_Role", "T_Group_Id", "dbo.T_Group");
            DropForeignKey("dbo.T_Group", "ParentId", "dbo.T_Group");
            DropForeignKey("dbo.T_Authority", "T_Group_Id", "dbo.T_Group");
            DropForeignKey("dbo.T_UserT_Authority", "T_Authority_Id", "dbo.T_Authority");
            DropForeignKey("dbo.T_UserT_Authority", "T_User_Id", "dbo.T_User");
            DropForeignKey("dbo.T_Role", "ParentId", "dbo.T_Role");
            DropForeignKey("dbo.T_RoleT_Authority", "T_Authority_Id", "dbo.T_Authority");
            DropForeignKey("dbo.T_RoleT_Authority", "T_Role_Id", "dbo.T_Role");
            DropForeignKey("dbo.T_Authority", "ParentId", "dbo.T_Authority");
            DropIndex("dbo.T_UserT_Role", new[] { "T_Role_Id" });
            DropIndex("dbo.T_UserT_Role", new[] { "T_User_Id" });
            DropIndex("dbo.T_GroupT_User", new[] { "T_User_Id" });
            DropIndex("dbo.T_GroupT_User", new[] { "T_Group_Id" });
            DropIndex("dbo.T_UserT_Authority", new[] { "T_Authority_Id" });
            DropIndex("dbo.T_UserT_Authority", new[] { "T_User_Id" });
            DropIndex("dbo.T_RoleT_Authority", new[] { "T_Authority_Id" });
            DropIndex("dbo.T_RoleT_Authority", new[] { "T_Role_Id" });
            DropIndex("dbo.T_OperatorLog", new[] { "UserId" });
            DropIndex("dbo.T_Group", new[] { "ParentId" });
            DropIndex("dbo.T_Role", new[] { "T_Group_Id" });
            DropIndex("dbo.T_Role", new[] { "ParentId" });
            DropIndex("dbo.T_Authority", new[] { "T_Group_Id" });
            DropIndex("dbo.T_Authority", new[] { "ParentId" });
            DropTable("dbo.T_UserT_Role");
            DropTable("dbo.T_GroupT_User");
            DropTable("dbo.T_UserT_Authority");
            DropTable("dbo.T_RoleT_Authority");
            DropTable("dbo.T_OperatorLog");
            DropTable("dbo.T_Group");
            DropTable("dbo.T_User");
            DropTable("dbo.T_Role");
            DropTable("dbo.T_Authority");
        }
    }
}
