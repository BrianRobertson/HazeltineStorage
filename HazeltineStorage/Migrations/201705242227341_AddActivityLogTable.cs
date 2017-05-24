namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivityLogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        LogDate = c.DateTime(nullable: false),
                        MessageType = c.String(),
                        Notes = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityLogs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActivityLogs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ActivityLogs", new[] { "UserId" });
            DropIndex("dbo.ActivityLogs", new[] { "CustomerId" });
            DropTable("dbo.ActivityLogs");
        }
    }
}
