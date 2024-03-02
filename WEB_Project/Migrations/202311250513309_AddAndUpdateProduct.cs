namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAndUpdateProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductTest", "ProductCategoryId", "dbo.tb_ProductCategory");
            //DropForeignKey("dbo.tb_ProductImage", "ProductTest_Id", "dbo.tb_ProductTest");
            //DropForeignKey("dbo.tb_ProductImage", "ProductTests_Id", "dbo.tb_ProductTest");
            //DropForeignKey("dbo.tb_ProductImage", "ProductTest_Id1", "dbo.tb_ProductTest");
            DropForeignKey("dbo.tb_ProductTest", "Provider_ProID", "dbo.tb_Provider");
            //DropForeignKey("dbo.tb_OrderDetail3", "ProductId", "dbo.tb_ProductTest");
            DropIndex("dbo.tb_ProductTest", new[] { "ProductCategoryId" });
            DropIndex("dbo.tb_ProductTest", new[] { "Provider_ProID" });
            DropIndex("dbo.tb_ProductImage", new[] { "ProductTest_Id" });
            DropIndex("dbo.tb_ProductImage", new[] { "ProductTests_Id" });
            DropIndex("dbo.tb_ProductImage", new[] { "ProductTest_Id1" });
            CreateTable(
                "dbo.tb_Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Alias = c.String(maxLength: 250),
                        Title = c.String(nullable: false, maxLength: 250),
                        ProductCode = c.String(maxLength: 50),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 250),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        IsHome = c.Boolean(nullable: false),
                        IsSale = c.Boolean(nullable: false),
                        IsFeature = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 250),
                        SeoKeywords = c.String(maxLength: 250),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Provider_ProID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.tb_ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Provider", t => t.Provider_ProID)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.Provider_ProID);
            

            // CHIỀU VỀ NHỚ XÓA CÁI BẢNG ORDERDETAIL3 RỒI THÊM LẠI, NHỚ ĐỂ Ý NGHIÊN CỨU CHỖ KHÓA NGOẠI VỚI BẢNG PRODUCT
            CreateIndex("dbo.tb_ProductImage", "ProductId");
            //AddForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product", "ProductID", cascadeDelete: true);
            //AddForeignKey("dbo.tb_OrderDetail3", "ProductId", "dbo.tb_Product", "ProductID", cascadeDelete: true);
            //DropColumn("dbo.tb_ProductImage", "ProductTest_Id");
            //DropColumn("dbo.tb_ProductImage", "ProductTests_Id");
            //DropColumn("dbo.tb_ProductImage", "ProductTest_Id1");
            DropTable("dbo.tb_ProductTest");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_ProductTest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Alias = c.String(maxLength: 250),
                        Title = c.String(nullable: false, maxLength: 250),
                        ProductCode = c.String(maxLength: 50),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 250),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        IsHome = c.Boolean(nullable: false),
                        IsSale = c.Boolean(nullable: false),
                        IsFeature = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 250),
                        SeoKeywords = c.String(maxLength: 250),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Provider_ProID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_ProductImage", "ProductTest_Id1", c => c.Int());
            AddColumn("dbo.tb_ProductImage", "ProductTests_Id", c => c.Int());
            AddColumn("dbo.tb_ProductImage", "ProductTest_Id", c => c.Int());
            DropForeignKey("dbo.tb_OrderDetail3", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider");
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            DropIndex("dbo.tb_Product", new[] { "Provider_ProID" });
            DropIndex("dbo.tb_Product", new[] { "ProductCategoryId" });
            DropTable("dbo.tb_Product");
            CreateIndex("dbo.tb_ProductImage", "ProductTest_Id1");
            CreateIndex("dbo.tb_ProductImage", "ProductTests_Id");
            CreateIndex("dbo.tb_ProductImage", "ProductTest_Id");
            CreateIndex("dbo.tb_ProductTest", "Provider_ProID");
            CreateIndex("dbo.tb_ProductTest", "ProductCategoryId");
            AddForeignKey("dbo.tb_OrderDetail3", "ProductId", "dbo.tb_ProductTest", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_ProductTest", "Provider_ProID", "dbo.tb_Provider", "ProID");
            AddForeignKey("dbo.tb_ProductImage", "ProductTest_Id1", "dbo.tb_ProductTest", "Id");
            AddForeignKey("dbo.tb_ProductImage", "ProductTests_Id", "dbo.tb_ProductTest", "Id");
            AddForeignKey("dbo.tb_ProductImage", "ProductTest_Id", "dbo.tb_ProductTest", "Id");
            AddForeignKey("dbo.tb_ProductTest", "ProductCategoryId", "dbo.tb_ProductCategory", "Id", cascadeDelete: true);
        }
    }
}
