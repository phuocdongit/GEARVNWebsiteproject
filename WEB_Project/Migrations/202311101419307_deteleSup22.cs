namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deteleSup22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "Supplier_SupID", "dbo.tb_Supplier");
            DropIndex("dbo.tb_Product", new[] { "Supplier_SupID" });
           
            
        }
        
        public override void Down()
        {
            
        }
    }
}
