﻿namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forthmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "Motor_MotorId", "dbo.Motors");
            DropIndex("dbo.Teams", new[] { "Motor_MotorId" });
            DropColumn("dbo.Teams", "Motor_MotorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Motor_MotorId", c => c.Int());
            CreateIndex("dbo.Teams", "Motor_MotorId");
            AddForeignKey("dbo.Teams", "Motor_MotorId", "dbo.Motors", "MotorId");
        }
    }
}
