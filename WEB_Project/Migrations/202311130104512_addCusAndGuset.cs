namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCusAndGuset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Customer",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        TypePayment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.tb_Guest",
                c => new
                    {
                        GuestID = c.String(nullable: false, maxLength: 128),
                        GuestName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        TypePayment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuestID);
            
            AddColumn("dbo.tb_Order", "GuessID", c => c.String());
            AddColumn("dbo.tb_Order", "CustomerID", c => c.String(maxLength: 128));
            AddColumn("dbo.tb_Order", "Guest_GuestID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Order", "CustomerID");
            CreateIndex("dbo.tb_Order", "Guest_GuestID");
            AddForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer", "CustomerID");
            AddForeignKey("dbo.tb_Order", "Guest_GuestID", "dbo.tb_Guest", "GuestID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Order", "Guest_GuestID", "dbo.tb_Guest");
            DropForeignKey("dbo.tb_Order", "CustomerID", "dbo.tb_Customer");
            DropIndex("dbo.tb_Order", new[] { "Guest_GuestID" });
            DropIndex("dbo.tb_Order", new[] { "CustomerID" });
            DropColumn("dbo.tb_Order", "Guest_GuestID");
            DropColumn("dbo.tb_Order", "CustomerID");
            DropColumn("dbo.tb_Order", "GuessID");
            DropTable("dbo.tb_Guest");
            DropTable("dbo.tb_Customer");
        }
    }
}
