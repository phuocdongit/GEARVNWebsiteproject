namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Role", newName: "tb_Quyen");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_Quyen", newName: "tb_Role");
        }
    }
}
