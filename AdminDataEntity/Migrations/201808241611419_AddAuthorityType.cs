namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorityType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_AuthorityType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.T_Authority", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.T_Authority", "TypeId");
            AddForeignKey("dbo.T_Authority", "TypeId", "dbo.T_AuthorityType", "Id", cascadeDelete: true);
            DropColumn("dbo.T_Role", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Role", "ParentId", c => c.Int());
            DropForeignKey("dbo.T_Authority", "TypeId", "dbo.T_AuthorityType");
            DropIndex("dbo.T_Authority", new[] { "TypeId" });
            DropColumn("dbo.T_Authority", "TypeId");
            DropTable("dbo.T_AuthorityType");
        }
    }
}
