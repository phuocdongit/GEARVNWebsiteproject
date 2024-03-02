namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dangerUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.a_Role", newName: "Role");
            RenameTable(name: "dbo.a_UserRole", newName: "RoleAccount");
            RenameTable(name: "dbo.a_User", newName: "UserAccount");
            RenameTable(name: "dbo.a_Claim", newName: "Claim");
            RenameTable(name: "dbo.a_Login", newName: "Login");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Login", newName: "a_Login");
            RenameTable(name: "dbo.Claim", newName: "a_Claim");
            RenameTable(name: "dbo.UserAccount", newName: "a_User");
            RenameTable(name: "dbo.RoleAccount", newName: "a_UserRole");
            RenameTable(name: "dbo.Role", newName: "a_Role");
        }
    }
}
