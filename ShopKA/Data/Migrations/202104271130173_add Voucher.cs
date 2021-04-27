namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVoucher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        OrderSale = c.Single(nullable: false),
                        ShipSale = c.Single(nullable: false),
                        TypeCondition = c.Boolean(nullable: false),
                        Condition = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vouchers");
        }
    }
}
