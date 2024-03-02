namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Alias", c => c.String(maxLength: 200));
            AlterColumn("dbo.Category", "Link", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Link", c => c.String());
            AlterColumn("dbo.Category", "Alias", c => c.String());
        }
    }
}
