namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delProvider : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider");
            DropIndex("dbo.tb_Product", new[] { "Provider_ProID" });
            DropColumn("dbo.tb_Product", "Provider_ProID");
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
            
            AddColumn("dbo.tb_Product", "Provider_ProID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Product", "Provider_ProID");
            AddForeignKey("dbo.tb_Product", "Provider_ProID", "dbo.tb_Provider", "ProID");
        }
    }
}
