namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordertable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipName", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "BillName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "BillName");
            DropColumn("dbo.Orders", "ShipName");
        }
    }
}
