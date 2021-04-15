namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituseroks2354 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password1", c => c.String(nullable: false, maxLength: 600));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password1", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
