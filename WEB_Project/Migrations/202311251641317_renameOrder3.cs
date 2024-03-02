namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameOrder3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Order3", newName: "tb_Order");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_Order", newName: "tb_Order3");
        }
    }
}
