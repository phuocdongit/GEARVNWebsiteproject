namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteIdInSupplier : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Supplier", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Supplier", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
