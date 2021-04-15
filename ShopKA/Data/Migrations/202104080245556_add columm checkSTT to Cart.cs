namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolummcheckSTTtoCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "checkSTT", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "checkSTT");
        }
    }
}
