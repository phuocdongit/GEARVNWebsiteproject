namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delODT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order3");
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropTable("dbo.tb_OrderDetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_OrderDetail",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId });
            
            CreateIndex("dbo.tb_OrderDetail", "ProductId");
            CreateIndex("dbo.tb_OrderDetail", "OrderId");
            AddForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order3", "Id", cascadeDelete: true);
        }
    }
}
