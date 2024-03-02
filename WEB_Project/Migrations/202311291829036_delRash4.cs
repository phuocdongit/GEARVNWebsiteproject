namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delRash4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Post", new[] { "CategoryId" });
            DropTable("dbo.tb_Post");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 250),
                        CategoryId = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_Post", "CategoryId");
            AddForeignKey("dbo.tb_Post", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
