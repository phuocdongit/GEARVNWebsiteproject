namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "CustomerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "CustomerName", c => c.String(nullable: false));
        }
    }
}
