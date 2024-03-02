namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropPrimaryKey("dbo.tb_Category");
            AddColumn("dbo.tb_Category", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_Category", "CategoryId");
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.tb_Category", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropPrimaryKey("dbo.tb_Category");
            DropColumn("dbo.tb_Category", "CategoryId");
            AddPrimaryKey("dbo.tb_Category", "Id");
            AddForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
