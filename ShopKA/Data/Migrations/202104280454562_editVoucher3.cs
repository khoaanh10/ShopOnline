namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editVoucher3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Type", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vouchers", "PriceOrderCondition", c => c.Int(nullable: false));
            AddColumn("dbo.Vouchers", "QuantityCondition", c => c.Int(nullable: false));
            DropColumn("dbo.Vouchers", "TypeCondition");
            DropColumn("dbo.Vouchers", "Condition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vouchers", "Condition", c => c.Int(nullable: false));
            AddColumn("dbo.Vouchers", "TypeCondition", c => c.Int(nullable: false));
            DropColumn("dbo.Vouchers", "QuantityCondition");
            DropColumn("dbo.Vouchers", "PriceOrderCondition");
            DropColumn("dbo.Vouchers", "Type");
        }
    }
}
