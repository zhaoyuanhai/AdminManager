namespace AdminDataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Name = c.String(),
                        Content = c.Binary(),
                        Type = c.String(),
                        Postfix = c.String(),
                        _CreateDate = c.DateTime(nullable: false),
                        _UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_File");
        }
    }
}
