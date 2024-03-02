namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDBUC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_UserAccount",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.tb_Quyen", t => t.RoleID)
                .Index(t => t.RoleID);
            
            AddColumn("dbo.tb_Order", "UserAccounts_UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Order", "UserAccounts_UserID");
            AddForeignKey("dbo.tb_Order", "UserAccounts_UserID", "dbo.tb_UserAccount", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_UserAccount", "RoleID", "dbo.tb_Quyen");
            DropForeignKey("dbo.tb_Order", "UserAccounts_UserID", "dbo.tb_UserAccount");
            DropIndex("dbo.tb_UserAccount", new[] { "RoleID" });
            DropIndex("dbo.tb_Order", new[] { "UserAccounts_UserID" });
            DropColumn("dbo.tb_Order", "UserAccounts_UserID");
            DropTable("dbo.tb_UserAccount");
        }
    }
}
