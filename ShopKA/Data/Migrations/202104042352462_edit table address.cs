namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Ward", c => c.String(nullable: false));
            DropColumn("dbo.Addresses", "DetailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "DetailAddress", c => c.String(nullable: false));
            DropColumn("dbo.Addresses", "Ward");
        }
    }
}
