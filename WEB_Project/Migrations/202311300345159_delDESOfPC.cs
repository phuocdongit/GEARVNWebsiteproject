namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delDESOfPC : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_ProductCategory", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "Description", c => c.String());
        }
    }
}
