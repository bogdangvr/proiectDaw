namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirteenthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leagues", "CreatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leagues", "CreatedTime");
        }
    }
}
