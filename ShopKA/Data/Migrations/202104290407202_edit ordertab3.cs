namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordertab3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SaleShip", c => c.Single(nullable: false));
            AddColumn("dbo.Orders", "SalePrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SalePrice");
            DropColumn("dbo.Orders", "SaleShip");
        }
    }
}
