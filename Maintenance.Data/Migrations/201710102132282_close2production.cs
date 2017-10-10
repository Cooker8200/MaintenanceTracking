namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class close2production : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServSafes", "Store", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServSafes", "Store");
        }
    }
}
