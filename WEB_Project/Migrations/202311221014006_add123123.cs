namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add123123 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.tb_OrderDetail", "Product_ProdId", "dbo.tb_Product");
            //DropForeignKey("dbo.tb_ProductImage", "Product_ProdId", "dbo.tb_Product");
            //DropIndex("dbo.tb_OrderDetail", new[] { "Product_ProdId" });
            //DropIndex("dbo.tb_ProductImage", new[] { "Product_ProdId" });
            //DropColumn("dbo.tb_OrderDetail", "ProductId");
            //DropColumn("dbo.tb_ProductImage", "ProductId");
            //RenameColumn(table: "dbo.tb_OrderDetail", name: "Product_ProdId", newName: "ProductId");
            //RenameColumn(table: "dbo.tb_ProductImage", name: "Product_ProdId", newName: "ProductId");
            //DropPrimaryKey("dbo.tb_OrderDetail");
            //DropPrimaryKey("dbo.tb_Product");
            //AddColumn("dbo.tb_Product", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            //AlterColumn("dbo.tb_ProductImage", "ProductId", c => c.Int(nullable: false));
            ////AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderId", "ProductId" });
            ////AddPrimaryKey("dbo.tb_Product", "Id");
            //CreateIndex("dbo.tb_OrderDetail", "ProductId");
            //CreateIndex("dbo.tb_ProductImage", "ProductId");
            //AddForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            //DropColumn("dbo.tb_Product", "ProdId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "ProdId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropPrimaryKey("dbo.tb_Product");
            DropPrimaryKey("dbo.tb_OrderDetail");
            AlterColumn("dbo.tb_ProductImage", "ProductId", c => c.Int());
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int());
            DropColumn("dbo.tb_Product", "Id");
            AddPrimaryKey("dbo.tb_Product", "ProdId");
            AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderId", "ProductId" });
            RenameColumn(table: "dbo.tb_ProductImage", name: "ProductId", newName: "Product_ProdId");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "ProductId", newName: "Product_ProdId");
            AddColumn("dbo.tb_ProductImage", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_ProductImage", "Product_ProdId");
            CreateIndex("dbo.tb_OrderDetail", "Product_ProdId");
            AddForeignKey("dbo.tb_ProductImage", "Product_ProdId", "dbo.tb_Product", "ProdId");
            AddForeignKey("dbo.tb_OrderDetail", "Product_ProdId", "dbo.tb_Product", "ProdId");
        }
    }
}
