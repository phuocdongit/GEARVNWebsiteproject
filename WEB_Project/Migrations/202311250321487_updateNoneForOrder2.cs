namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNoneForOrder2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order2");
            DropPrimaryKey("dbo.tb_Order2");
            AlterColumn("dbo.tb_Order2", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_Order2", "Id");
            AddForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order2", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order2");
            DropPrimaryKey("dbo.tb_Order2");
            AlterColumn("dbo.tb_Order2", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_Order2", "Id");
            AddForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order2", "Id", cascadeDelete: true);
        }
    }
}
