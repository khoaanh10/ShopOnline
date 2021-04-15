namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShipsttandbillsttforaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "ShipStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Addresses", "BillStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Addresses", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Addresses", "BillStatus");
            DropColumn("dbo.Addresses", "ShipStatus");
        }
    }
}
