namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleleOrderAndOrderdetailGoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer");
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.tb_Order", new[] { "CustomerID" });
            DropTable("dbo.tb_OrderDetail");
            DropTable("dbo.tb_Order");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            
            CreateTable(
                "dbo.tb_OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_Order", "CustomerID");
            CreateIndex("dbo.tb_OrderDetail", "ProductId");
            CreateIndex("dbo.tb_OrderDetail", "OrderId");
            AddForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer", "CustomerID");
        }
    }
}
