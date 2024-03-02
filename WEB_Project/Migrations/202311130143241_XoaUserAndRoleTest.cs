namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XoaUserAndRoleTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Order", "UserAccounts_UserID", "dbo.tb_UserAccount");
            DropForeignKey("dbo.tb_UserAccount", "RoleID", "dbo.tb_Quyen");
            DropIndex("dbo.tb_Order", new[] { "UserAccounts_UserID" });
            DropIndex("dbo.tb_UserAccount", new[] { "RoleID" });
            DropColumn("dbo.tb_Order", "UserAccounts_UserID");
            DropTable("dbo.tb_UserAccount");
            DropTable("dbo.tb_Quyen");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Quyen",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
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
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.tb_Order", "UserAccounts_UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_UserAccount", "RoleID");
            CreateIndex("dbo.tb_Order", "UserAccounts_UserID");
            AddForeignKey("dbo.tb_UserAccount", "RoleID", "dbo.tb_Quyen", "RoleID");
            AddForeignKey("dbo.tb_Order", "UserAccounts_UserID", "dbo.tb_UserAccount", "UserID");
        }
    }
}
