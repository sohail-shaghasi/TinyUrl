namespace Nintex.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinyUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongUrl = c.String(maxLength: 100, storeType: "nvarchar"),
                        ShortUrl = c.String(maxLength: 100, storeType: "nvarchar"),
                        Segment = c.String(maxLength: 100, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinyUrls");
        }
    }
}
