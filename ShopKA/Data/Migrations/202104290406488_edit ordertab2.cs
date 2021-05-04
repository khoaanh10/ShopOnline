namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordertab2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "SaleShip");
            DropColumn("dbo.Orders", "SalePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "SalePrice", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "SaleShip", c => c.Int(nullable: false));
        }
    }
}
