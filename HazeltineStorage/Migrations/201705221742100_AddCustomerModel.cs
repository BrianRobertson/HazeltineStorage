namespace HazeltineStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                        Type = c.String(),
                        Status = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        MainPhone = c.String(),
                        MobilePhone = c.String(),
                        TextNotification = c.Boolean(nullable: false),
                        EmailAddress = c.String(),
                        EmailNotification = c.Boolean(nullable: false),
                        EmailInvoice = c.Boolean(nullable: false),
                        CustomerBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
