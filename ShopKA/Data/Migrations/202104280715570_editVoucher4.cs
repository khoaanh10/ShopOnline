namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editVoucher4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SalePrice", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Maximum", c => c.Int(nullable: false));
            AddColumn("dbo.Vouchers", "Maximum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vouchers", "Maximum");
            DropColumn("dbo.Orders", "Maximum");
            DropColumn("dbo.Orders", "SalePrice");
        }
    }
}
