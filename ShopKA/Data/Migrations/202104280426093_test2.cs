namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Vouchers");
        }
        
        public override void Down()
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
    }
}
