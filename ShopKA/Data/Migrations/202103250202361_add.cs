namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sale", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "SaleTime", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "View", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "View");
            DropColumn("dbo.Products", "SaleTime");
            DropColumn("dbo.Products", "Sale");
        }
    }
}
