namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tb_OrderDetail", "OrderId");
            AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
        }
    }
}
