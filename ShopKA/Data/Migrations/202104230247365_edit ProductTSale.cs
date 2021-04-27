namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProductTSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTSales", "Title", c => c.String(nullable: false));
            AddColumn("dbo.ProductTSales", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTSales", "Content");
            DropColumn("dbo.ProductTSales", "Title");
        }
    }
}
