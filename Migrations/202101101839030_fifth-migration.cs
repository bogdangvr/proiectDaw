namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Motors", "ExpectedFinish", c => c.Int(nullable: false));
            DropColumn("dbo.Motors", "ExpectedAverageFinish");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Motors", "ExpectedAverageFinish", c => c.Double(nullable: false));
            DropColumn("dbo.Motors", "ExpectedFinish");
        }
    }
}
