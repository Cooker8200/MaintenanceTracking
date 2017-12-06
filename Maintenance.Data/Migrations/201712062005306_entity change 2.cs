namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitychange2 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.HepAs", "Store");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HepAs", "Store", c => c.String());
        }
    }
}
