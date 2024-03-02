namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFKOD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_OrderDetail", new[] { "ProductId" });
            DropPrimaryKey("dbo.tb_OrderDetail");
            AddColumn("dbo.tb_OrderDetail", "Product_Id", c => c.Int());
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String());
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.tb_OrderDetail", "ProductId");
            //CreateIndex("dbo.tb_OrderDetail", "Product_Id");
            //AddForeignKey("dbo.tb_OrderDetail", "Product_Id", "dbo.tb_Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_OrderDetail", new[] { "Product_Id" });
            DropPrimaryKey("dbo.tb_OrderDetail");
            AlterColumn("dbo.tb_OrderDetail", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.tb_OrderDetail", "Product_Id");
            AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderId", "ProductId" });
            CreateIndex("dbo.tb_OrderDetail", "ProductId");
            AddForeignKey("dbo.tb_OrderDetail", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
    }
}
