namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udOD : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.tb_OrderDetail", "Order_Code", "dbo.tb_Order");
            //DropForeignKey("dbo.tb_OrderDetail", "Product_Id", "dbo.tb_Product");
            //DropIndex("dbo.tb_OrderDetail", new[] { "Order_Code" });
            //DropIndex("dbo.tb_OrderDetail", new[] { "Product_Id" });
            //DropColumn("dbo.tb_OrderDetail", "OrderId");
            //DropColumn("dbo.tb_OrderDetail", "ProductId");
            //RenameColumn(table: "dbo.tb_OrderDetail", name: "Order_Code", newName: "OrderId");
            //RenameColumn(table: "dbo.tb_OrderDetail", name: "Product_Id", newName: "ProductId");
            //DropPrimaryKey("dbo.tb_OrderDetail");
            //AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            //AlterColumn("dbo.tb_Order", "Code", c => c.String(nullable: false, maxLength: 10));
            //AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 10));
            ////AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropPrimaryKey("dbo.tb_OrderDetail");
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int());
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(maxLength: 128));
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String());
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_OrderDetail", "ProductId");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "OrderId", newName: "Order_Code");
            AddColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.tb_OrderDetail", "OrderId", c => c.String());
            CreateIndex("dbo.tb_OrderDetail", "Product_Id");
            CreateIndex("dbo.tb_OrderDetail", "Order_Code");
            AddForeignKey("dbo.tb_OrderDetail", "Product_Id", "dbo.tb_Product", "Id");
            AddForeignKey("dbo.tb_OrderDetail", "Order_Code", "dbo.tb_Order", "Code");
        }
    }
}
