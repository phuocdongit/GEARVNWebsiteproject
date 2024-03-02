namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategory", "HomeAvatar", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductImage", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Provider", "Phone", c => c.String(maxLength: 15));
            AlterColumn("dbo.Provider", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Subscribe", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribe", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Provider", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Provider", "Phone", c => c.String(maxLength: 100));
            AlterColumn("dbo.ProductImage", "Image", c => c.String());
            AlterColumn("dbo.ProductCategory", "HomeAvatar", c => c.String());
        }
    }
}
