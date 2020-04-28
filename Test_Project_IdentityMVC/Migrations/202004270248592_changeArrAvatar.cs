namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeArrAvatar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Avatar", c => c.Binary());
        }
    }
}
