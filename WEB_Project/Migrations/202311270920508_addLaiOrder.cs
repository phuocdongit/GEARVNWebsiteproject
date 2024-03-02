namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLaiOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer");
            CreateTable(
                "dbo.tb_Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        LadingCode = c.String(nullable: false),
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
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.tb_Customer", t => t.CustomerID);
            
            DropTable("dbo.tb_Order");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Order",
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
            
            DropForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer");
            DropTable("dbo.tb_Order");
            AddForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer", "CustomerID");
        }
    }
}
