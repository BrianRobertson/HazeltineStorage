namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTypeFKIsNullableOnCustomerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            AlterColumn("dbo.Customers", "CustomerTypeId", c => c.Byte());
            CreateIndex("dbo.Customers", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            AlterColumn("dbo.Customers", "CustomerTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id", cascadeDelete: true);
        }
    }
}
