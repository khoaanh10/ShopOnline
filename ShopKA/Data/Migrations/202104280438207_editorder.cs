namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SaleShip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SaleShip");
        }
    }
}
