namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleventhmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leagues", "AllowedDriverId", c => c.Int());
            AlterColumn("dbo.Leagues", "AllowedTeamId", c => c.Int());
            AlterColumn("dbo.Leagues", "AllowedMotorId", c => c.Int());
            DropColumn("dbo.Rosters", "LeagueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rosters", "LeagueId", c => c.Int(nullable: false));
            AlterColumn("dbo.Leagues", "AllowedMotorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Leagues", "AllowedTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Leagues", "AllowedDriverId", c => c.Int(nullable: false));
        }
    }
}
