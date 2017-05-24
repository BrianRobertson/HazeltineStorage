namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        ForMonthOf = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                        TotalDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.Contracts", "Invoice_Id", c => c.Int());
            AddColumn("dbo.Products", "TermAtRate", c => c.String());
            AddColumn("dbo.Products", "Invoice_Id", c => c.Int());
            CreateIndex("dbo.Contracts", "Invoice_Id");
            CreateIndex("dbo.Products", "Invoice_Id");
            AddForeignKey("dbo.Contracts", "Invoice_Id", "dbo.Invoices", "Id");
            AddForeignKey("dbo.Products", "Invoice_Id", "dbo.Invoices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "Invoice_Id", "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "Invoice_Id" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Contracts", new[] { "Invoice_Id" });
            DropColumn("dbo.Products", "Invoice_Id");
            DropColumn("dbo.Products", "TermAtRate");
            DropColumn("dbo.Contracts", "Invoice_Id");
            DropTable("dbo.Invoices");
        }
    }
}
