namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taobanag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ColorName = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProducerName = c.String(nullable: false),
                        ProductTID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProducerID = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        Configuration = c.String(),
                        Price = c.Int(),
                        Status = c.Boolean(nullable: false),
                        Image = c.String(maxLength: 2000),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProducTName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductTs");
            DropTable("dbo.Products");
            DropTable("dbo.Producers");
            DropTable("dbo.Colors");
        }
    }
}
