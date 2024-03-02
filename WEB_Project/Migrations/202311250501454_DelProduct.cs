namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelProduct : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Product", newName: "tb_ProductTest");
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            AddColumn("dbo.tb_ProductImage", "ProductTest_Id", c => c.Int());
            AddColumn("dbo.tb_ProductImage", "ProductTests_Id", c => c.Int());
            AddColumn("dbo.tb_ProductImage", "ProductTest_Id1", c => c.Int());
            CreateIndex("dbo.tb_ProductImage", "ProductTest_Id");
            CreateIndex("dbo.tb_ProductImage", "ProductTests_Id");
            CreateIndex("dbo.tb_ProductImage", "ProductTest_Id1");
            AddForeignKey("dbo.tb_ProductImage", "ProductTest_Id", "dbo.tb_ProductTest", "Id");
            AddForeignKey("dbo.tb_ProductImage", "ProductTests_Id", "dbo.tb_ProductTest", "Id");
            AddForeignKey("dbo.tb_ProductImage", "ProductTest_Id1", "dbo.tb_ProductTest", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductImage", "ProductTest_Id1", "dbo.tb_ProductTest");
            DropForeignKey("dbo.tb_ProductImage", "ProductTests_Id", "dbo.tb_ProductTest");
            DropForeignKey("dbo.tb_ProductImage", "ProductTest_Id", "dbo.tb_ProductTest");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductTest_Id1" });
            DropIndex("dbo.tb_ProductImage", new[] { "ProductTests_Id" });
            DropIndex("dbo.tb_ProductImage", new[] { "ProductTest_Id" });
            DropColumn("dbo.tb_ProductImage", "ProductTest_Id1");
            DropColumn("dbo.tb_ProductImage", "ProductTests_Id");
            DropColumn("dbo.tb_ProductImage", "ProductTest_Id");
            CreateIndex("dbo.tb_ProductImage", "ProductId");
            AddForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.tb_ProductTest", newName: "tb_Product");
        }
    }
}
