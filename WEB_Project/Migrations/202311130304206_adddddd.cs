namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddddd : DbMigration
    {
        public override void Up()
        {
            // Thêm cột OrderId và làm khóa chính
            //AddColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 10));
            //AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderId", "ProductId" });

            // Thêm ràng buộc khóa ngoại mới
            //AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "Code");
            //AddForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "Order_Code", "dbo.tb_Order");
            DropIndex("dbo.tb_OrderDetail", new[] { "Order_Code" });
            DropColumn("dbo.tb_OrderDetail", "Order_Code");
            CreateIndex("dbo.tb_OrderDetail", "OrderId");
            AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "Code", cascadeDelete: true);
        }
    }
}
