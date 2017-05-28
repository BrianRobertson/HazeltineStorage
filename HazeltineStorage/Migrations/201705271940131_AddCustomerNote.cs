namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerNote");
        }
    }
}
