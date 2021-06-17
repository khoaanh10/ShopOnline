namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
