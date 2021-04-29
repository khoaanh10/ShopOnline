namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vouchers", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vouchers", "Quantity", c => c.Int(nullable: false));
        }
    }
}
