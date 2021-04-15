namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editusers2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fullname", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Birthday", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "Fullname");
        }
    }
}
