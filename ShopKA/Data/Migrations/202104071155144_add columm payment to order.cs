namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolummpaymenttoorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "payment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "payment");
        }
    }
}
