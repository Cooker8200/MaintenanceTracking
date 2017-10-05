namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaintenanceLogs", "Misc", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.MaintenanceLogs", "Misc");
        }

    }
}
