namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProductTSale2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductTSales", "Banner", c => c.String());
            AlterColumn("dbo.ProductTSales", "Title", c => c.String());
            AlterColumn("dbo.ProductTSales", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductTSales", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.ProductTSales", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ProductTSales", "Banner", c => c.String(nullable: false));
        }
    }
}
