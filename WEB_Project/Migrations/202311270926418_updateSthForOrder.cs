namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSthForOrder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Orders", "Quantity");
            DropColumn("dbo.tb_Orders", "CreatedBy");
            DropColumn("dbo.tb_Orders", "ModifiedBy");
            DropColumn("dbo.tb_Orders", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Order", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Order", "Quantity", c => c.Int(nullable: false));
        }
    }
}
