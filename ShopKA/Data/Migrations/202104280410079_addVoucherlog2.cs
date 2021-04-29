namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVoucherlog2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vouchers", "Quantity");
        }
    }
}
