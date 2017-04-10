namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finishentityContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsPrivateBirthDate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Contacts", "IsPrivatePhone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "ImageData", c => c.Binary());
            AddColumn("dbo.Contacts", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ImageMimeType");
            DropColumn("dbo.Contacts", "ImageData");
            DropColumn("dbo.Contacts", "IsPrivatePhone");
            DropColumn("dbo.Contacts", "BirthDate");
            DropColumn("dbo.Contacts", "IsPrivateBirthDate");
        }
    }
}
