namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsPrivatePhoto", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "IsPrivatePhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "IsPrivatePhone", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "IsPrivatePhoto");
        }
    }
}
