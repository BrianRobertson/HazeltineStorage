namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKPaymentTypeToPaymentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Payments", "PaymentTypeId");
            AddForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Payments", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.String());
            DropForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.Payments", new[] { "PaymentTypeId" });
            DropColumn("dbo.Payments", "PaymentTypeId");
        }
    }
}
