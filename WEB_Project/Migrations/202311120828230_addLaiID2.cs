namespace WEB_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLaiID2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Supplier", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Supplier", "Id", c => c.String(nullable: false));
        }
    }
}
