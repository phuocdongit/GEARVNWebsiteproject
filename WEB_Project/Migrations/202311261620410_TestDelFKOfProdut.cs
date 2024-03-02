namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDelFKOfProdut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider");
            DropIndex("dbo.tb_Product", new[] { "Provider_ProID" });
            DropColumn("dbo.tb_Product", "Provider_ProID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "Provider_ProID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Product", "Provider_ProID");
            AddForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider", "ProID");
        }
    }
}
