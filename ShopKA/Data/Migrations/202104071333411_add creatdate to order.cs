namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcreatdatetoorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreatDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CreatDate");
        }
    }
}
