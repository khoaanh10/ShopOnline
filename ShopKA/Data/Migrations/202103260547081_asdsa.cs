namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Launch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Launch");
        }
    }
}
