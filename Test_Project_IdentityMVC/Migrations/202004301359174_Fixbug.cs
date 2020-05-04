namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixbug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "UpdateById", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
            CreateIndex("dbo.AspNetUsers", "UpdateById");
            AddForeignKey("dbo.AspNetUsers", "UpdateById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UpdateById", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "UpdateById" });
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.String());
            DropColumn("dbo.AspNetUsers", "UpdateById");
            DropColumn("dbo.AspNetUsers", "UpdatedAt");
        }
    }
}
