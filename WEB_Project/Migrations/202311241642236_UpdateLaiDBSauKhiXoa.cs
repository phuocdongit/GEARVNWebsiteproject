namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLaiDBSauKhiXoa : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.tb_OrderDetail", "Order_CodeID", "dbo.tb_Order");
            //DropIndex("dbo.tb_OrderDetail", new[] { "Order_CodeID" });
            //DropColumn("dbo.tb_OrderDetail", "OrderId");
            //RenameColumn(table: "dbo.tb_OrderDetail", name: "Order_CodeID", newName: "OrderId");
            //DropPrimaryKey("dbo.tb_Order");
            //DropPrimaryKey("dbo.tb_OrderDetail");
            CreateTable(
                "dbo.tb_Order2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Code = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        TypePayment = c.Int(nullable: false),
                        CustomerID = c.String(maxLength: 128),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Customer", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.tb_OrderDetail2",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.tb_Order2", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            //AddColumn("dbo.tb_Order", "Id", c => c.Int(nullable: false, identity: false));
            //AddColumn("dbo.tb_Order", "Code", c => c.String(nullable: false));
            //AddColumn("dbo.tb_OrderDetail", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int(nullable: false));
            //AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.tb_Order", "Id");
            //AddPrimaryKey("dbo.tb_OrderDetail", "Id");
            //CreateIndex("dbo.tb_OrderDetail", "OrderId");
            //AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
            //DropColumn("dbo.tb_Order", "CodeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "CodeID", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropForeignKey("dbo.tb_OrderDetail2", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail2", "OrderId", "dbo.tb_Order2");
            DropForeignKey("dbo.tb_Order2", "CustomerID", "dbo.tb_Customer");
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.tb_OrderDetail2", new[] { "ProductId" });
            DropIndex("dbo.tb_OrderDetail2", new[] { "OrderId" });
            DropIndex("dbo.tb_Order2", new[] { "CustomerID" });
            DropPrimaryKey("dbo.tb_OrderDetail");
            DropPrimaryKey("dbo.tb_Order");
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(maxLength: 128));
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.tb_OrderDetail", "Id");
            DropColumn("dbo.tb_Order", "Code");
            DropColumn("dbo.tb_Order", "Id");
            DropTable("dbo.tb_OrderDetail2");
            DropTable("dbo.tb_Order2");
            AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderId", "ProductId" });
            AddPrimaryKey("dbo.tb_Order", "CodeID");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "OrderId", newName: "Order_CodeID");
            AddColumn("dbo.tb_OrderDetail", "OrderId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tb_OrderDetail", "Order_CodeID");
            AddForeignKey("dbo.tb_OrderDetail", "Order_CodeID", "dbo.tb_Order", "CodeID");
        }
    }
}
