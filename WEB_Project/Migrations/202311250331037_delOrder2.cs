namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delOrder2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail2", "Order", "dbo.tb_Order2");
            DropForeignKey("dbo.tb_Order2", "CustomerID", "dbo.tb_Customer");
            DropIndex("dbo.tb_Order2", new[] { "CustomerID" });
            DropTable("dbo.tb_Order2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Order2",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        TypePayment = c.Int(nullable: false),
                        CustomerID = c.String(maxLength: 128),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_Order2", "CustomerID");
            AddForeignKey("dbo.tb_Order2", "CustomerID", "dbo.tb_Customer", "CustomerID");
        }
    }
}
