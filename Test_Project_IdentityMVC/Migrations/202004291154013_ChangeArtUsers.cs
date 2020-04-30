namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeArtUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UpdatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "UpdateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UpdateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "UpdatedDate");
        }
    }
}
