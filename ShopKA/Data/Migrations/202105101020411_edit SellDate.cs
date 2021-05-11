namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editSellDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SellDates", "Voucher", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SellDates", "Voucher");
        }
    }
}
