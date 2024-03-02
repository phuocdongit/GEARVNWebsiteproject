namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delGuest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Order", "Guest_GuestID", "dbo.tb_Guest");
            DropIndex("dbo.tb_Order", new[] { "Guest_GuestID" });
            DropColumn("dbo.tb_Order", "Guest_GuestID");
            DropTable("dbo.tb_Guest");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.tb_Order", "Guest_GuestID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Order", "Guest_GuestID");
            AddForeignKey("dbo.tb_Order", "Guest_GuestID", "dbo.tb_Guest", "GuestID");
        }
    }
}
