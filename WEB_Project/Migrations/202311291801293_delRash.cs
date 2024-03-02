namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delRash : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropPrimaryKey("dbo.tb_Category");
            AlterColumn("dbo.tb_Category", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_Category", "Id");
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_Category", "Description");
            DropColumn("dbo.tb_Category", "SeoTitle");
            DropColumn("dbo.tb_Category", "SeoDescription");
            DropColumn("dbo.tb_Category", "SeoKeywords");
            DropColumn("dbo.tb_Category", "CreatedBy");
            DropColumn("dbo.tb_Category", "CreatedDate");
            DropColumn("dbo.tb_Category", "ModifiedBy");
            DropColumn("dbo.tb_Category", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Category", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Category", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Category", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Category", "SeoKeywords", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Category", "SeoDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Category", "SeoTitle", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Category", "Description", c => c.String());
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropPrimaryKey("dbo.tb_Category");
            AlterColumn("dbo.tb_Category", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_Category", "Id");
            AddForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
