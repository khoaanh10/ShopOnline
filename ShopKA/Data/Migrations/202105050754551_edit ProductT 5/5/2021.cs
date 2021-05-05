namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProductT552021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTs", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTs", "Image");
        }
    }
}
