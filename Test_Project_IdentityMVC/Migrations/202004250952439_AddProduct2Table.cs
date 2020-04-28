namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduct2Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        Price = c.Double(nullable: false),
                        Thumbnails = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product2");
        }
    }
}
