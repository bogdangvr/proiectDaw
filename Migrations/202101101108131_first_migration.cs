namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Nationality = c.String(nullable: false),
                        ExpectedFinish = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.PastExperiences",
                c => new
                    {
                        DriverId = c.Int(nullable: false),
                        Description = c.String(),
                        JuniorExperience = c.String(),
                        FirstRace = c.String(),
                        SupportChampionships = c.String(),
                        RaceStarts = c.Int(nullable: false),
                        Podiums = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        WorldChampionships = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Rosters",
                c => new
                    {
                        RosterId = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        UniqueCode = c.String(nullable: false),
                        TeamId = c.Int(nullable: false),
                        MotorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RosterId)
                .ForeignKey("dbo.Motors", t => t.MotorId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.MotorId);
            
            CreateTable(
                "dbo.Motors",
                c => new
                    {
                        MotorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ExpectedAverageFinish = c.Double(nullable: false),
                        Price = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MotorId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ExpectedFinish = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Motor_MotorId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Motors", t => t.Motor_MotorId)
                .Index(t => t.Motor_MotorId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RosterDrivers",
                c => new
                    {
                        Roster_RosterId = c.Int(nullable: false),
                        Driver_DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Roster_RosterId, t.Driver_DriverId })
                .ForeignKey("dbo.Rosters", t => t.Roster_RosterId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverId, cascadeDelete: true)
                .Index(t => t.Roster_RosterId)
                .Index(t => t.Driver_DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rosters", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Motor_MotorId", "dbo.Motors");
            DropForeignKey("dbo.Drivers", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Rosters", "MotorId", "dbo.Motors");
            DropForeignKey("dbo.RosterDrivers", "Driver_DriverId", "dbo.Drivers");
            DropForeignKey("dbo.RosterDrivers", "Roster_RosterId", "dbo.Rosters");
            DropForeignKey("dbo.PastExperiences", "DriverId", "dbo.Drivers");
            DropIndex("dbo.RosterDrivers", new[] { "Driver_DriverId" });
            DropIndex("dbo.RosterDrivers", new[] { "Roster_RosterId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Teams", new[] { "Motor_MotorId" });
            DropIndex("dbo.Rosters", new[] { "MotorId" });
            DropIndex("dbo.Rosters", new[] { "TeamId" });
            DropIndex("dbo.PastExperiences", new[] { "DriverId" });
            DropIndex("dbo.Drivers", new[] { "Team_TeamId" });
            DropTable("dbo.RosterDrivers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.Motors");
            DropTable("dbo.Rosters");
            DropTable("dbo.PastExperiences");
            DropTable("dbo.Drivers");
        }
    }
}
