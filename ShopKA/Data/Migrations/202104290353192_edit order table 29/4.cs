namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordertable294 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Voucher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Voucher");
        }
    }
}
