namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaLaiFK : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order");
        }
    }
}
