namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.Drivers", new[] { "Team_TeamId" });
            DropColumn("dbo.Drivers", "Team_TeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Drivers", "Team_TeamId");
            AddForeignKey("dbo.Drivers", "Team_TeamId", "dbo.Teams", "TeamId");
        }
    }
}
