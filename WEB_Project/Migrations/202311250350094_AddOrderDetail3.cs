namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderDetail3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "Order3_Id", "dbo.tb_Order3");
            DropIndex("dbo.tb_OrderDetail", new[] { "Order3_Id" });
            CreateTable(
                "dbo.tb_OrderDetail3",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.tb_Order3", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.tb_OrderDetail", "Order3_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_OrderDetail", "Order3_Id", c => c.Int());
            DropForeignKey("dbo.tb_OrderDetail3", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail3", "OrderId", "dbo.tb_Order3");
            DropIndex("dbo.tb_OrderDetail3", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail3", new[] { "OrderId" });
            DropTable("dbo.tb_OrderDetail3");
            CreateIndex("dbo.tb_OrderDetail", "Order3_Id");
            AddForeignKey("dbo.tb_OrderDetail", "Order3_Id", "dbo.tb_Order3", "Id");
        }
    }
}
