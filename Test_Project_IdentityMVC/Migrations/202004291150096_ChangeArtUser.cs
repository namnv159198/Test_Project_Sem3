namespace Test_Project_IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeArtUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "Subject", c => c.String());
            AddColumn("dbo.Feedbacks", "Content", c => c.String());
            AddColumn("dbo.Feedbacks", "Name", c => c.String(maxLength: 100));
            AddColumn("dbo.Feedbacks", "CreateAt", c => c.DateTime());
            AddColumn("dbo.Feedbacks", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Feedbacks", "HandleAt", c => c.DateTime());
            AddColumn("dbo.Feedbacks", "UpdateById", c => c.String(maxLength: 128));
            AddColumn("dbo.Feedbacks", "DeleteById", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdateById", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UpdateById");
            CreateIndex("dbo.Feedbacks", "DeleteById");
            CreateIndex("dbo.AspNetUsers", "UpdateById");
            AddForeignKey("dbo.AspNetUsers", "UpdateById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Feedbacks", "DeleteById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Feedbacks", "UpdateById", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Feedbacks", "Answer");
            DropColumn("dbo.Feedbacks", "Comment");
            DropColumn("dbo.Feedbacks", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "Fullname", c => c.String(maxLength: 100));
            AddColumn("dbo.Feedbacks", "Comment", c => c.String(maxLength: 500));
            AddColumn("dbo.Feedbacks", "Answer", c => c.Int());
            DropForeignKey("dbo.Feedbacks", "UpdateById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "DeleteById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UpdateById", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "UpdateById" });
            DropIndex("dbo.Feedbacks", new[] { "DeleteById" });
            DropIndex("dbo.Feedbacks", new[] { "UpdateById" });
            DropColumn("dbo.AspNetUsers", "UpdateById");
            DropColumn("dbo.AspNetUsers", "UpdateDate");
            DropColumn("dbo.Feedbacks", "DeleteById");
            DropColumn("dbo.Feedbacks", "UpdateById");
            DropColumn("dbo.Feedbacks", "HandleAt");
            DropColumn("dbo.Feedbacks", "DeletedAt");
            DropColumn("dbo.Feedbacks", "CreateAt");
            DropColumn("dbo.Feedbacks", "Name");
            DropColumn("dbo.Feedbacks", "Content");
            DropColumn("dbo.Feedbacks", "Subject");
        }
    }
}
