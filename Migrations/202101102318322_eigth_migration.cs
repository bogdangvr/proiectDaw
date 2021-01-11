namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eigth_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leagues", "AllowedDriverId", c => c.Int(nullable: false));
            AddColumn("dbo.Leagues", "AllowedTeamId", c => c.Int(nullable: false));
            AddColumn("dbo.Leagues", "AllowedMotorId", c => c.Int(nullable: false));
            AddColumn("dbo.Leagues", "Prize", c => c.String());
            AddColumn("dbo.Leagues", "AllowedDriver_DriverId", c => c.Int());
            AddColumn("dbo.Leagues", "AllowedMotor_MotorId", c => c.Int());
            AddColumn("dbo.Leagues", "AllowedTeam_TeamId", c => c.Int());
            CreateIndex("dbo.Leagues", "AllowedDriver_DriverId");
            CreateIndex("dbo.Leagues", "AllowedMotor_MotorId");
            CreateIndex("dbo.Leagues", "AllowedTeam_TeamId");
            AddForeignKey("dbo.Leagues", "AllowedDriver_DriverId", "dbo.Drivers", "DriverId");
            AddForeignKey("dbo.Leagues", "AllowedMotor_MotorId", "dbo.Motors", "MotorId");
            AddForeignKey("dbo.Leagues", "AllowedTeam_TeamId", "dbo.Teams", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leagues", "AllowedTeam_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Leagues", "AllowedMotor_MotorId", "dbo.Motors");
            DropForeignKey("dbo.Leagues", "AllowedDriver_DriverId", "dbo.Drivers");
            DropIndex("dbo.Leagues", new[] { "AllowedTeam_TeamId" });
            DropIndex("dbo.Leagues", new[] { "AllowedMotor_MotorId" });
            DropIndex("dbo.Leagues", new[] { "AllowedDriver_DriverId" });
            DropColumn("dbo.Leagues", "AllowedTeam_TeamId");
            DropColumn("dbo.Leagues", "AllowedMotor_MotorId");
            DropColumn("dbo.Leagues", "AllowedDriver_DriverId");
            DropColumn("dbo.Leagues", "Prize");
            DropColumn("dbo.Leagues", "AllowedMotorId");
            DropColumn("dbo.Leagues", "AllowedTeamId");
            DropColumn("dbo.Leagues", "AllowedDriverId");
        }
    }
}
