namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituseroks28354 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Fullname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Fullname", c => c.String());
        }
    }
}
