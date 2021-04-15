namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituseroks234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Permission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Permission");
        }
    }
}
