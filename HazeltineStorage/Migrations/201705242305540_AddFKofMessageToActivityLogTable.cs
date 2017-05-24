namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKofMessageToActivityLogTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLogs", "MessageId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActivityLogs", "MessageId");
            AddForeignKey("dbo.ActivityLogs", "MessageId", "dbo.Messages", "Id", cascadeDelete: true);
            DropColumn("dbo.ActivityLogs", "MessageType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityLogs", "MessageType", c => c.String());
            DropForeignKey("dbo.ActivityLogs", "MessageId", "dbo.Messages");
            DropIndex("dbo.ActivityLogs", new[] { "MessageId" });
            DropColumn("dbo.ActivityLogs", "MessageId");
        }
    }
}
