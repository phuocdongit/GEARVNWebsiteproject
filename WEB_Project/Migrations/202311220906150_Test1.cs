namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "CodeID", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
        }
    }
}
