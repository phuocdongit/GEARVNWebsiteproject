namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Product", newName: "Product");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Product", newName: "tb_Product");
        }
    }
}
