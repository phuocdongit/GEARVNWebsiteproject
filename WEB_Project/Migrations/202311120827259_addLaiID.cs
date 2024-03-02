namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLaiID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Supplier", "Id", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Supplier", "Id");
        }
    }
}
