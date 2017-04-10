namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maintenancecontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Login", c => c.String());
            AddColumn("dbo.Contacts", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Password");
            DropColumn("dbo.Contacts", "Login");
        }
    }
}
