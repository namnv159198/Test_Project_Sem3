namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}
