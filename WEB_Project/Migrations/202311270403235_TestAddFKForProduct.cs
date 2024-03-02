namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAddFKForProduct : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tb_Product", "ProviderID");
            AddForeignKey("dbo.tb_Product", "ProviderID", "dbo.tb_Provider", "ProID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "ProviderID", "dbo.tb_Provider");
            DropIndex("dbo.tb_Product", new[] { "ProviderID" });
        }
    }
}
