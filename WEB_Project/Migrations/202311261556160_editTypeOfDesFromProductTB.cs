namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editTypeOfDesFromProductTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Description", c => c.String(maxLength: 50));
        }
    }
}
