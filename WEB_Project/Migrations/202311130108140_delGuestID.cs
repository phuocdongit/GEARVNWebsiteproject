namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delGuestID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "GuessID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "GuessID", c => c.String());
        }
    }
}
