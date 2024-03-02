namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProvider1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Provider",
                c => new
                    {
                        ProID = c.Int(nullable: false),
                        ProName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProID);
            
            AlterColumn("dbo.tb_Product", "ProviderID", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Product", "ProviderID");
            AddForeignKey("dbo.tb_Product", "ProviderID", "dbo.tb_Provider", "ProID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "ProviderID", "dbo.tb_Provider");
            DropIndex("dbo.tb_Product", new[] { "ProviderID" });
            AlterColumn("dbo.tb_Product", "ProviderID", c => c.String());
            DropTable("dbo.tb_Provider");
        }
    }
}
