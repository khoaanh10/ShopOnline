namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sale2", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "SaleTimeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "SaleTimeEnd", c => c.DateTime(nullable: false));
            DropTable("dbo.SaleProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Sale = c.Single(nullable: false),
                        SaleTimeStart = c.DateTime(nullable: false),
                        SaleTimeEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Products", "SaleTimeEnd");
            DropColumn("dbo.Products", "SaleTimeStart");
            DropColumn("dbo.Products", "Sale2");
        }
    }
}
