namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdIntoSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Supplier", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Supplier", "Id");
        }
    }
}
