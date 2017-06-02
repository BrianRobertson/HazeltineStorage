namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBalanceIsNullableOnCustomerTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerBalance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
