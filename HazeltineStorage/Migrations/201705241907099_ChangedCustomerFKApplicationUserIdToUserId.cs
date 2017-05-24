namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCustomerFKApplicationUserIdToUserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "ApplicationUserId", newName: "UserId");
            RenameIndex(table: "dbo.Customers", name: "IX_ApplicationUserId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_UserId", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "ApplicationUserId");
        }
    }
}
