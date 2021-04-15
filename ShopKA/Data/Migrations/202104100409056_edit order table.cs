namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipAddress", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "ShipPhone", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "BillAddress", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "BillPhone", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "ShipAddressID");
            DropColumn("dbo.Orders", "BillAddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "BillAddressID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShipAddressID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "BillPhone");
            DropColumn("dbo.Orders", "BillAddress");
            DropColumn("dbo.Orders", "ShipPhone");
            DropColumn("dbo.Orders", "ShipAddress");
        }
    }
}
