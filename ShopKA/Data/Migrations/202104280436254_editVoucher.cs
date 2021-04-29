namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editVoucher : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vouchers", "TypeCondition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vouchers", "TypeCondition", c => c.Boolean(nullable: false));
        }
    }
}
