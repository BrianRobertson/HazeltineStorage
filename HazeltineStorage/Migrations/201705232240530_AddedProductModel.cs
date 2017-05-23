namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitNumber = c.String(),
                        UnitDescription = c.String(),
                        RentalRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ContractId", "dbo.Contracts");
            DropIndex("dbo.Products", new[] { "ContractId" });
            DropTable("dbo.Products");
        }
    }
}
