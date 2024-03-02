namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delRash2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_News", "SeoTitle");
            DropColumn("dbo.tb_News", "SeoDescription");
            DropColumn("dbo.tb_News", "SeoKeywords");
            DropColumn("dbo.tb_News", "CreatedBy");
            DropColumn("dbo.tb_News", "ModifiedBy");
            DropColumn("dbo.tb_News", "ModifiedDate");
            DropColumn("dbo.tb_Post", "CreatedBy");
            DropColumn("dbo.tb_Post", "ModifiedBy");
            DropColumn("dbo.tb_Post", "ModifiedDate");
            DropColumn("dbo.tb_Contact", "CreatedBy");
            DropColumn("dbo.tb_Contact", "ModifiedBy");
            DropColumn("dbo.tb_Contact", "ModifiedDate");
            DropColumn("dbo.tb_Product", "CreatedBy");
            DropColumn("dbo.tb_Product", "ModifiedBy");
            DropColumn("dbo.tb_Product", "ModifiedDate");
            DropColumn("dbo.tb_ProductCategory", "CreatedBy");
            DropColumn("dbo.tb_ProductCategory", "ModifiedBy");
            DropColumn("dbo.tb_ProductCategory", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_ProductCategory", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_ProductCategory", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Product", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Product", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Product", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Contact", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Contact", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Contact", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Post", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Post", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Post", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_News", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_News", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_News", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_News", "SeoKeywords", c => c.String());
            AddColumn("dbo.tb_News", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_News", "SeoTitle", c => c.String());
        }
    }
}
