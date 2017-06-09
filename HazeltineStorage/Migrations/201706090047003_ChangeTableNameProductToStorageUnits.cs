namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableNameProductToStorageUnits : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "StorageUnits");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StorageUnits", newName: "Products");
        }
    }
}
