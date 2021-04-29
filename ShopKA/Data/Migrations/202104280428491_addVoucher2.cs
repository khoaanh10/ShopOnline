namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVoucher2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        OrderSale = c.Single(nullable: false),
                        ShipSale = c.Single(nullable: false),
                        TypeCondition = c.Boolean(nullable: false),
                        Condition = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vouchers");
        }
    }
}
