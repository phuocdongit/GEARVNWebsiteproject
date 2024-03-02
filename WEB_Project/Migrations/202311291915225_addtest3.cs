namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtest3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductCategorye",
                c => new
                    {
                        ProductCatId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Icon = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCatId);

            //AddColumn("dbo.tb_Product", "Avatar", c => c.String(maxLength: 250));
            //DropColumn("dbo.tb_Product", "Image");
            //DropColumn("dbo.tb_Product", "SeoTitle");
            //DropColumn("dbo.tb_Product", "SeoDescription");
            //DropColumn("dbo.tb_Product", "SeoKeywords");
            //DropTable("dbo.tb_ProductCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Icon = c.String(maxLength: 250),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Product", "SeoKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Product", "SeoDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Product", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 250));
            DropColumn("dbo.tb_Product", "Avatar");
            DropTable("dbo.tb_ProductCategorye");
        }
    }
}
