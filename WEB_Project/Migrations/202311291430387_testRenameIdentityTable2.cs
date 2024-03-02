namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testRenameIdentityTable2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Role", newName: "a_Role");
            RenameTable(name: "dbo.UserRole", newName: "a_UserRole");
            RenameTable(name: "dbo.User", newName: "a_User");
            RenameTable(name: "dbo.Claim", newName: "a_Claim");
            RenameTable(name: "dbo.Login", newName: "a_Login");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.a_Login", newName: "Login");
            RenameTable(name: "dbo.a_Claim", newName: "Claim");
            RenameTable(name: "dbo.a_User", newName: "User");
            RenameTable(name: "dbo.a_UserRole", newName: "UserRole");
            RenameTable(name: "dbo.a_Role", newName: "Role");
        }
    }
}
