namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStringNews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.News", "Image", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Image", c => c.String());
            AlterColumn("dbo.News", "Alias", c => c.String());
        }
    }
}
