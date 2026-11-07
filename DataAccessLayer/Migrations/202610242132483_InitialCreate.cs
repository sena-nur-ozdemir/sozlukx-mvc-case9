namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(),
                        AboutDetails2 = c.String(),
                        AboutImage1 = c.String(),
                        AboutImage2 = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(nullable: false, maxLength: 50),
                        AdminMail = c.String(nullable: false, maxLength: 100),
                        AdminPasswordHash = c.String(),
                        AdminPasswordSalt = c.String(),
                        AdminRole = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryStatus = c.Boolean(nullable: false),
                        CategoryDescription = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 150),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Writers", t => t.WriterID)
                .Index(t => t.CategoryID)
                .Index(t => t.WriterID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(),
                        ContentDate = c.DateTime(nullable: false),
                        HeadingID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Headings", t => t.HeadingID)
                .ForeignKey("dbo.Writers", t => t.WriterID)
                .Index(t => t.HeadingID)
                .Index(t => t.WriterID);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterID = c.Int(nullable: false, identity: true),
                        WriterName = c.String(),
                        WriterSurname = c.String(),
                        WriterUserName = c.String(maxLength: 50),
                        WriterMail = c.String(),
                        WriterPasswordHash = c.String(),
                        WriterPasswordSalt = c.String(),
                        WriterImage = c.String(),
                        WriterTitle = c.String(),
                        WriterAbout = c.String(),
                        WriterStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WriterID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserMail = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        ContactDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(nullable: false, maxLength: 100),
                        ReceiverMail = c.String(nullable: false, maxLength: 100),
                        Subject = c.String(maxLength: 150),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsDraft = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            DropIndex("dbo.Headings", new[] { "WriterID" });
            DropIndex("dbo.Headings", new[] { "CategoryID" });
            DropTable("dbo.Messages");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Contacts");
            DropTable("dbo.Writers");
            DropTable("dbo.Contents");
            DropTable("dbo.Headings");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
