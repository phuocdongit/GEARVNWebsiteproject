namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testLai : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_ProductImage");
            AlterColumn("dbo.tb_ProductImage", "ProductImageId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_ProductImage", "ProductImageId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_ProductImage");
            AlterColumn("dbo.tb_ProductImage", "ProductImageId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_ProductImage", "ProductImageId");
        }
    }
}
