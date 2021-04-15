namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image2", c => c.String());
            AddColumn("dbo.Products", "Image3", c => c.String());
            AddColumn("dbo.Products", "Image4", c => c.String());
            AddColumn("dbo.Products", "Image5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Image5");
            DropColumn("dbo.Products", "Image4");
            DropColumn("dbo.Products", "Image3");
            DropColumn("dbo.Products", "Image2");
        }
    }
}
