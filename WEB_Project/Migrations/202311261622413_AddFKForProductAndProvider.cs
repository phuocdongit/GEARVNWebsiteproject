namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKForProductAndProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "ProviderID", c => c.String());
            AddColumn("dbo.tb_Product", "Provider_ProID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Product", "Provider_ProID");
            AddForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider", "ProID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider");
            DropIndex("dbo.tb_Product", new[] { "Provider_ProID" });
            DropColumn("dbo.tb_Product", "Provider_ProID");
            DropColumn("dbo.tb_Product", "ProviderID");
        }
    }
}
