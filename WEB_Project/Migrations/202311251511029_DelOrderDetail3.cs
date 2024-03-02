namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelOrderDetail3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_OrderDetail3", newName: "tb_OrderDetail");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_OrderDetail", newName: "tb_OrderDetail3");
        }
    }
}
