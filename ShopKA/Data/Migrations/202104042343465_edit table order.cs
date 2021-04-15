namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "ProvinceID", c => c.String(nullable: false));
            AddColumn("dbo.Addresses", "DistrictID", c => c.String(nullable: false));
            AddColumn("dbo.Addresses", "DetailAddress", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "ShipAddressID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "BillAddressID", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "Provincial");
            DropColumn("dbo.Addresses", "District");
            DropColumn("dbo.Addresses", "Commune");
            DropColumn("dbo.Orders", "AddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "AddressID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "Commune", c => c.String(nullable: false));
            AddColumn("dbo.Addresses", "District", c => c.String(nullable: false));
            AddColumn("dbo.Addresses", "Provincial", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "BillAddressID");
            DropColumn("dbo.Orders", "ShipAddressID");
            DropColumn("dbo.Addresses", "DetailAddress");
            DropColumn("dbo.Addresses", "DistrictID");
            DropColumn("dbo.Addresses", "ProvinceID");
        }
    }
}
