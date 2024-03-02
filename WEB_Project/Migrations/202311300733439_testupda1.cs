namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testupda1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_ProductImage");
            AddColumn("dbo.tb_ProductImage", "ProductImageId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_ProductImage", "ProductImageId");
            DropColumn("dbo.tb_ProductImage", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductImage", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.tb_ProductImage");
            DropColumn("dbo.tb_ProductImage", "ProductImageId");
            AddPrimaryKey("dbo.tb_ProductImage", "Id");
        }
    }
}
