namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameOrder_Orders : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Order", newName: "Orders");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Orders", newName: "Order");
        }
    }
}
