namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "LadingCode", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Orders", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "LadingCode", c => c.String(nullable: false));
        }
    }
}
