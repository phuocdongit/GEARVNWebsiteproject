namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Supplier",
                c => new
                    {
                        SupID = c.String(nullable: false, maxLength: 128),
                        SupName = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupID);
            
            AddColumn("dbo.tb_Product", "Supplier_SupID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Product", "Supplier_SupID");
            AddForeignKey("dbo.tb_Product", "Supplier_SupID", "dbo.tb_Supplier", "SupID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "Supplier_SupID", "dbo.tb_Supplier");
            DropIndex("dbo.tb_Product", new[] { "Supplier_SupID" });
            DropColumn("dbo.tb_Product", "Supplier_SupID");
            DropTable("dbo.tb_Supplier");
        }
    }
}
