namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Status");
        }
    }
}
