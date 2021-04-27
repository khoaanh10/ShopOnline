namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProductTSale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTSales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductTID = c.Int(nullable: false),
                        Sale = c.Single(nullable: false),
                        SaleTimeStart = c.DateTime(nullable: false),
                        SaleTimeEnd = c.DateTime(nullable: false),
                        Banner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductTSales");
        }
    }
}
