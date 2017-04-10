namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Country = c.String(),
                        City = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 350),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        PhoneTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneTypes", t => t.PhoneTypeId, cascadeDelete: true)
                .Index(t => t.PhoneTypeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.PhoneTypes",
                c => new
                    {
                        PhoneTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneTypeId);
            
            CreateTable(
                "dbo.QuickLists",
                c => new
                    {
                        QuickListId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuickListId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 350),
                        Login = c.String(nullable: false, maxLength: 350),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Login, unique: true);
            
            CreateTable(
                "dbo.QuickListContacts",
                c => new
                    {
                        QuickList_QuickListId = c.Int(nullable: false),
                        Contact_ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuickList_QuickListId, t.Contact_ContactId })
                .ForeignKey("dbo.QuickLists", t => t.QuickList_QuickListId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId, cascadeDelete: true)
                .Index(t => t.QuickList_QuickListId)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuickLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.QuickListContacts", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.QuickListContacts", "QuickList_QuickListId", "dbo.QuickLists");
            DropForeignKey("dbo.Phones", "PhoneTypeId", "dbo.PhoneTypes");
            DropForeignKey("dbo.Phones", "ContactId", "dbo.Contacts");
            DropIndex("dbo.QuickListContacts", new[] { "Contact_ContactId" });
            DropIndex("dbo.QuickListContacts", new[] { "QuickList_QuickListId" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.QuickLists", new[] { "UserId" });
            DropIndex("dbo.Phones", new[] { "ContactId" });
            DropIndex("dbo.Phones", new[] { "PhoneTypeId" });
            DropIndex("dbo.Contacts", new[] { "Email" });
            DropTable("dbo.QuickListContacts");
            DropTable("dbo.Users");
            DropTable("dbo.QuickLists");
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.Phones");
            DropTable("dbo.Contacts");
        }
    }
}
