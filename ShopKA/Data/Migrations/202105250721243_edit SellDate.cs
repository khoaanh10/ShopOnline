namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editSellDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SellDates", "Voucher", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SellDates", "Voucher", c => c.String(nullable: false));
        }
    }
}
