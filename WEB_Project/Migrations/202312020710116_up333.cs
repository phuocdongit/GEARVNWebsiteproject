namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up333 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customer", "CustomerID");
        }
    }
}
