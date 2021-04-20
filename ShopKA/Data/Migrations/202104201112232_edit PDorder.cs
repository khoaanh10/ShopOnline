namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPDorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrders", "PDName", c => c.String(nullable: false));
            AddColumn("dbo.ProductOrders", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.ProductOrders", "ColorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOrders", "ColorID", c => c.Int(nullable: false));
            DropColumn("dbo.ProductOrders", "Price");
            DropColumn("dbo.ProductOrders", "PDName");
        }
    }
}
