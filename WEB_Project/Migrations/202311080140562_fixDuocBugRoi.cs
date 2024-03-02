namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDuocBugRoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "OriginalPrice");
        }
    }
}
