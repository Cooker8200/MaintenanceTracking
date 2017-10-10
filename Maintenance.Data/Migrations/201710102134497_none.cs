namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class none : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServSafes", "Misc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServSafes", "Misc");
        }
    }
}
