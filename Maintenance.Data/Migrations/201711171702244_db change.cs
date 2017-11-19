namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StoreLists", newName: "OldStores");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Stores", newName: "StoreLists");
        }
    }
}
