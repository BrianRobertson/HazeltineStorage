namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToContractTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "DayOfMonthDue", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "DayOfMonthGracePeriodEnds", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "ContractTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Contracts", "DueDate");
            DropColumn("dbo.Contracts", "GracePeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "GracePeriod", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "DueDate", c => c.Int(nullable: false));
            DropColumn("dbo.Contracts", "ContractTotal");
            DropColumn("dbo.Contracts", "DayOfMonthGracePeriodEnds");
            DropColumn("dbo.Contracts", "DayOfMonthDue");
        }
    }
}
