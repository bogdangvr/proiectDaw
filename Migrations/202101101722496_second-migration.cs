namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LeagueId);
            
            AddColumn("dbo.Rosters", "League_LeagueId", c => c.Int());
            CreateIndex("dbo.Rosters", "League_LeagueId");
            AddForeignKey("dbo.Rosters", "League_LeagueId", "dbo.Leagues", "LeagueId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rosters", "League_LeagueId", "dbo.Leagues");
            DropIndex("dbo.Rosters", new[] { "League_LeagueId" });
            DropColumn("dbo.Rosters", "League_LeagueId");
            DropTable("dbo.Leagues");
        }
    }
}
