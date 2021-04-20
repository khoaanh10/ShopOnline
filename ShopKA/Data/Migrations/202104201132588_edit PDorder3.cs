namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPDorder3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrders", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrders", "Image");
        }
    }
}
