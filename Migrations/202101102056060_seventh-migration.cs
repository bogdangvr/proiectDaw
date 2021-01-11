namespace fantasyF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventhmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rosters", "UniqueCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rosters", "UniqueCode", c => c.String(nullable: false));
        }
    }
}
