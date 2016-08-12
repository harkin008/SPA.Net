namespace SPA_AngularJs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        publisher = c.String(),
                        Isbn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.books");
        }
    }
}
