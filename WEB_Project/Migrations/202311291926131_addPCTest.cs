namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPCTest : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategorye");
            CreateTable(
                "dbo.tb_ProductCategory",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        HomeAvatar = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            AddForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory", "ProductCategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory");
            DropTable("dbo.tb_ProductCategory");
            AddForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategorye", "ProductCatId", cascadeDelete: true);
        }
    }
}
