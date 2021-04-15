namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableProduct2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sale2", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "SaleTimeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "SaleTimeEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "SaleTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "SaleTime", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "SaleTimeEnd");
            DropColumn("dbo.Products", "SaleTimeStart");
            DropColumn("dbo.Products", "Sale2");
        }
    }
}
