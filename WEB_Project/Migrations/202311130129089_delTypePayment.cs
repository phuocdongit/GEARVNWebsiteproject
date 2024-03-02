namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delTypePayment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Customer", "TypePayment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Customer", "TypePayment", c => c.Int(nullable: false));
        }
    }
}
