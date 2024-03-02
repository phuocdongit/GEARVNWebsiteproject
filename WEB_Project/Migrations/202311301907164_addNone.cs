namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNone : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_News");
            AlterColumn("dbo.tb_News", "NewId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_News", "NewId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_News");
            AlterColumn("dbo.tb_News", "NewId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_News", "NewId");
        }
    }
}
