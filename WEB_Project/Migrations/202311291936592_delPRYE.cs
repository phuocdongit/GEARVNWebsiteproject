namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delPRYE : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tb_ProductCategorye");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_ProductCategorye",
                c => new
                    {
                        ProductCatId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Icon = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCatId);
            
        }
    }
}
