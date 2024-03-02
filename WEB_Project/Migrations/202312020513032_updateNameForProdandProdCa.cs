namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNameForProdandProdCa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "StatusPayment", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductName", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.ProductCategory", "ProductCategoryName", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Order", "TypePayment");
            DropColumn("dbo.Product", "Title");
            DropColumn("dbo.ProductCategory", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategory", "Title", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Product", "Title", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Order", "TypePayment", c => c.Int(nullable: false));
            DropColumn("dbo.ProductCategory", "ProductCategoryName");
            DropColumn("dbo.Product", "ProductName");
            DropColumn("dbo.Order", "StatusPayment");
        }
    }
}
