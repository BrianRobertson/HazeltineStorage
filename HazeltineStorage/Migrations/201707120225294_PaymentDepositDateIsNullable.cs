namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentDepositDateIsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "DepositDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "DepositDate", c => c.DateTime(nullable: false));
        }
    }
}
