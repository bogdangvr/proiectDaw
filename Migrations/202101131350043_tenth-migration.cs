namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenthmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rosters", "League_LeagueId", "dbo.Leagues");
            DropIndex("dbo.Rosters", new[] { "League_LeagueId" });
            CreateTable(
                "dbo.RosterLeagues",
                c => new
                    {
                        Roster_RosterId = c.Int(nullable: false),
                        League_LeagueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Roster_RosterId, t.League_LeagueId })
                .ForeignKey("dbo.Rosters", t => t.Roster_RosterId, cascadeDelete: true)
                .ForeignKey("dbo.Leagues", t => t.League_LeagueId, cascadeDelete: true)
                .Index(t => t.Roster_RosterId)
                .Index(t => t.League_LeagueId);
            
            AddColumn("dbo.Rosters", "LeagueId", c => c.Int(nullable: false));
            DropColumn("dbo.Rosters", "League_LeagueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rosters", "League_LeagueId", c => c.Int());
            DropForeignKey("dbo.RosterLeagues", "League_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.RosterLeagues", "Roster_RosterId", "dbo.Rosters");
            DropIndex("dbo.RosterLeagues", new[] { "League_LeagueId" });
            DropIndex("dbo.RosterLeagues", new[] { "Roster_RosterId" });
            DropColumn("dbo.Rosters", "LeagueId");
            DropTable("dbo.RosterLeagues");
            CreateIndex("dbo.Rosters", "League_LeagueId");
            AddForeignKey("dbo.Rosters", "League_LeagueId", "dbo.Leagues", "LeagueId");
        }
    }
}
