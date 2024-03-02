namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up555 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customer", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
        }
    }
}
