namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerStatusFKIsNullableOnCustomerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus");
            DropIndex("dbo.Customers", new[] { "CustomerStatusId" });
            AlterColumn("dbo.Customers", "CustomerStatusId", c => c.Byte());
            CreateIndex("dbo.Customers", "CustomerStatusId");
            AddForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus");
            DropIndex("dbo.Customers", new[] { "CustomerStatusId" });
            AlterColumn("dbo.Customers", "CustomerStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "CustomerStatusId");
            AddForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus", "Id", cascadeDelete: true);
        }
    }
}
