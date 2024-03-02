namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNews : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_News");
            AddColumn("dbo.tb_News", "NewId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_News", "NewId");
            DropColumn("dbo.tb_News", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_News", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.tb_News");
            DropColumn("dbo.tb_News", "NewId");
            AddPrimaryKey("dbo.tb_News", "Id");
        }
    }
}
