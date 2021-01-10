namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rosters", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Rosters", "User", c => c.String());
            DropColumn("dbo.AspNetUsers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            DropColumn("dbo.Rosters", "User");
            DropColumn("dbo.Rosters", "Price");
        }
    }
}
