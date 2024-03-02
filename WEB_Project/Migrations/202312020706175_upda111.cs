namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upda111 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "CustomerID", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customer", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "CustomerID", c => c.String(maxLength: 10));
            AddPrimaryKey("dbo.Customer", "CustomerID");
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customer", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Orders", "CustomerID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customer", "Email", c => c.String());
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customer", "CustomerID");
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customer", "CustomerID");
        }
    }
}
