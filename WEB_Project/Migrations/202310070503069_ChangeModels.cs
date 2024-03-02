namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "ProductCategoryID", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_Product", new[] { "ProductCategoryID" });
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategoryID", newName: "ProductCategory_Id");
            AddColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Post", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Post", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Post", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "Title", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "ProductCategory_Id", c => c.Int());
            AlterColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "SeoDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "SeoKeywords", c => c.String(maxLength: 250));
            CreateIndex("dbo.tb_Product", "ProductCategory_Id");
            AddForeignKey("dbo.tb_Product", "ProductCategory_Id", "dbo.tb_ProductCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "ProductCategory_Id", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_Product", new[] { "ProductCategory_Id" });
            AlterColumn("dbo.tb_Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Product", "Image", c => c.String());
            AlterColumn("dbo.tb_Product", "ProductCategory_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Product", "Title", c => c.String());
            AlterColumn("dbo.tb_Product", "Alias", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Post", "Image", c => c.String());
            AlterColumn("dbo.tb_Post", "Alias", c => c.String());
            DropColumn("dbo.tb_Product", "ProductCode");
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategory_Id", newName: "ProductCategoryID");
            CreateIndex("dbo.tb_Product", "ProductCategoryID");
            AddForeignKey("dbo.tb_Product", "ProductCategoryID", "dbo.tb_ProductCategory", "Id", cascadeDelete: true);
        }
    }
}
