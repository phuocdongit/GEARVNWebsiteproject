namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSubscribe : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tb_Subcribe");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Subcribe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
