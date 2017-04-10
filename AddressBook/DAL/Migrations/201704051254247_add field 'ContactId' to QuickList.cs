namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfieldContactIdtoQuickList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuickLists", "ContactId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuickLists", "ContactId");
        }
    }
}
