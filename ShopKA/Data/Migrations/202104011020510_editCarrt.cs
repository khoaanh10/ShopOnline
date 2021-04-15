namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCarrt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ColorID", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "ProductID", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "ColorID");
        }
    }
}
