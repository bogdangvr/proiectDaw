namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twelfthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Photo", c => c.String());
            AddColumn("dbo.Motors", "Photo", c => c.String());
            AddColumn("dbo.Teams", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Photo");
            DropColumn("dbo.Motors", "Photo");
            DropColumn("dbo.Drivers", "Photo");
        }
    }
}
