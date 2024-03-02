namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Post",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 250),
                        CategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.tb_Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Post", new[] { "CategoryId" });
            DropTable("dbo.tb_Post");
        }
    }
}
