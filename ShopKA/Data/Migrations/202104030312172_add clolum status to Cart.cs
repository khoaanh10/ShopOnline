namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclolumstatustoCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Status");
        }
    }
}
