namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPDorder2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrders", "ColorID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrders", "ColorID");
        }
    }
}
