namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuickLists", "UserId", "dbo.Users");
            DropIndex("dbo.QuickLists", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropColumn("dbo.QuickLists", "UserId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuickLists", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Login", unique: true);
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.QuickLists", "UserId");
            AddForeignKey("dbo.QuickLists", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
