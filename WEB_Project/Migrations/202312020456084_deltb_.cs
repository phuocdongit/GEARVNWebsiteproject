namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deltb_ : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Category", newName: "Category");
            RenameTable(name: "dbo.tb_News", newName: "News");
            RenameTable(name: "dbo.tb_Post", newName: "Post");
            RenameTable(name: "dbo.tb_Customer", newName: "Customer");
            RenameTable(name: "dbo.tb_Order", newName: "Order");
            RenameTable(name: "dbo.tb_OrderDetail", newName: "OrderDetail");
            RenameTable(name: "dbo.tb_ProductCategory", newName: "ProductCategory");
            RenameTable(name: "dbo.tb_ProductImage", newName: "ProductImage");
            RenameTable(name: "dbo.tb_Provider", newName: "Provider");
            RenameTable(name: "dbo.tb_Subscribe", newName: "Subscribe");
            RenameTable(name: "dbo.tb_SystemSetting", newName: "SystemSetting");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SystemSetting", newName: "tb_SystemSetting");
            RenameTable(name: "dbo.Subscribe", newName: "tb_Subscribe");
            RenameTable(name: "dbo.Provider", newName: "tb_Provider");
            RenameTable(name: "dbo.ProductImage", newName: "tb_ProductImage");
            RenameTable(name: "dbo.ProductCategory", newName: "tb_ProductCategory");
            RenameTable(name: "dbo.OrderDetail", newName: "tb_OrderDetail");
            RenameTable(name: "dbo.Order", newName: "tb_Order");
            RenameTable(name: "dbo.Customer", newName: "tb_Customer");
            RenameTable(name: "dbo.Post", newName: "tb_Post");
            RenameTable(name: "dbo.News", newName: "tb_News");
            RenameTable(name: "dbo.Category", newName: "tb_Category");
        }
    }
}
