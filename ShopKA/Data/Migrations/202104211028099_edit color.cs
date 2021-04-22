namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcolor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colors", "SellQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "SellQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "SellQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Colors", "SellQuantity");
        }
    }
}
