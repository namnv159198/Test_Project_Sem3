namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "Answer", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Answer", c => c.Int(nullable: false));
        }
    }
}
