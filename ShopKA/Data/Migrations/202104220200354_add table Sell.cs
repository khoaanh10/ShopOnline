namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableSell : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellDates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SellPDID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateSell = c.DateTime(nullable: false),
                        BuyName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SellProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ColorID = c.Int(nullable: false),
                        PDName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SellProducts");
            DropTable("dbo.SellDates");
        }
    }
}
