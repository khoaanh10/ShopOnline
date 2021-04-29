namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVoucherlog21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voucherlogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voucherlogs");
        }
    }
}
