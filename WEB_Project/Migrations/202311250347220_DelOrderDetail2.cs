namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelOrderDetail2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order3");
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order");
            DropForeignKey("dbo.tb_OrderDetail2", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_OrderDetail2", new[] { "OrderId" });
            DropIndex("dbo.tb_OrderDetail2", new[] { "ProductId" });
            AddColumn("dbo.tb_OrderDetail", "Order3_Id", c => c.Int());
            CreateIndex("dbo.tb_OrderDetail", "Order3_Id");
            AddForeignKey("dbo.tb_OrderDetail", "Order3_Id", "dbo.tb_Order3", "Id");
            DropTable("dbo.tb_OrderDetail2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_OrderDetail2",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId });
            
            DropForeignKey("dbo.tb_OrderDetail", "Order3_Id", "dbo.tb_Order3");
            DropIndex("dbo.tb_OrderDetail", new[] { "Order3_Id" });
            DropColumn("dbo.tb_OrderDetail", "Order3_Id");
            CreateIndex("dbo.tb_OrderDetail2", "ProductId");
            CreateIndex("dbo.tb_OrderDetail2", "OrderId");
            AddForeignKey("dbo.tb_OrderDetail2", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order3", "Id", cascadeDelete: true);
        }
    }
}
