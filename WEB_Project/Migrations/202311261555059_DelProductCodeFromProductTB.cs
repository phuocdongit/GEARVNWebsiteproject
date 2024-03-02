namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelProductCodeFromProductTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Description", c => c.String(maxLength: 50));
            DropColumn("dbo.tb_Product", "ProductCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Product", "Description", c => c.String());
        }
    }
}
