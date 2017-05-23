namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerStatusModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        StatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "CustomerStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "CustomerStatusId");
            AddForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Status", c => c.String());
            DropForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus");
            DropIndex("dbo.Customers", new[] { "CustomerStatusId" });
            DropColumn("dbo.Customers", "CustomerStatusId");
            DropTable("dbo.CustomerStatus");
        }
    }
}
