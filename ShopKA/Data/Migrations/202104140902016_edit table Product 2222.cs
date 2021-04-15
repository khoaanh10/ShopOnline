namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableProduct2222 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "View1", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SellQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "View");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "View", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "SellQuantity");
            DropColumn("dbo.Products", "View1");
        }
    }
}
