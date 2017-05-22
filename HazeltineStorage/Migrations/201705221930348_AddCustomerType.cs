namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Type", c => c.String());
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            DropColumn("dbo.Customers", "CustomerTypeId");
            DropTable("dbo.CustomerTypes");
        }
    }
}
