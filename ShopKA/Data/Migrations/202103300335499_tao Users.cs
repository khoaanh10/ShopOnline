namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taoUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Password1 = c.String(nullable: false, maxLength: 20),
                        Password2 = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
