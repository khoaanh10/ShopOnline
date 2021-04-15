namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CreatDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "CreatDate");
        }
    }
}
