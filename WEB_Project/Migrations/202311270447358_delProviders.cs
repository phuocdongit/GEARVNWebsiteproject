namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delProviders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "ProviderID", "dbo.tb_Provider");
            DropIndex("dbo.tb_Product", new[] { "ProviderID" });
            AlterColumn("dbo.tb_Product", "ProviderID", c => c.String());
            DropTable("dbo.tb_Provider");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Provider",
                c => new
                    {
                        ProID = c.String(nullable: false, maxLength: 128),
                        ProName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProID);
            
            AlterColumn("dbo.tb_Product", "ProviderID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Product", "ProviderID");
            AddForeignKey("dbo.tb_Product", "ProviderID", "dbo.tb_Provider", "ProID");
        }
    }
}
