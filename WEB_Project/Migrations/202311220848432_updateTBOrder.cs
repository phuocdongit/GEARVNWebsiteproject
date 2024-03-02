namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTBOrder : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.tb_OrderDetail", "Order_Code", "dbo.tb_Order");
            //RenameColumn(table: "dbo.tb_OrderDetail", name: "Order_Code", newName: "Order_CodeID");
            //RenameIndex(table: "dbo.tb_OrderDetail", name: "IX_Order_Code", newName: "IX_Order_CodeID");
            //DropPrimaryKey("dbo.tb_Order");
            //DropColumn("dbo.tb_Order", "Code");

            AddColumn("dbo.tb_Order", "CodeID", c => c.String(nullable: false, maxLength: 10));
            //AddPrimaryKey("dbo.tb_Order", "CodeID");
            //AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "CodeID");
            //DropColumn("dbo.tb_Order", "Code");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.tb_Order", "Code", c => c.String(nullable: false, maxLength: 128));
            //DropForeignKey("dbo.tb_OrderDetail", "Order_CodeID", "dbo.tb_Order");
            //DropPrimaryKey("dbo.tb_Order");
            //DropColumn("dbo.tb_Order", "CodeID");
            //AddPrimaryKey("dbo.tb_Order", "Code");
            //RenameIndex(table: "dbo.tb_OrderDetail", name: "IX_Order_CodeID", newName: "IX_Order_Code");
            //RenameColumn(table: "dbo.tb_OrderDetail", name: "Order_CodeID", newName: "Order_Code");
            //AddForeignKey("dbo.tb_OrderDetail", "Order_Code", "dbo.tb_Order", "Code");
        }
    }
}
