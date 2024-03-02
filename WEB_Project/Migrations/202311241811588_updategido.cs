namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updategido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
        }
    }
}