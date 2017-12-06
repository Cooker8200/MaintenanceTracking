namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.HepAs", "EmpId", c => c.Int(nullable: false));
            //AddColumn("dbo.ServSafes", "EmpId", c => c.Int(nullable: false));
            //DropColumn("dbo.HepAs", "EmpName");
            //DropColumn("dbo.ServSafes", "EmpName");
            //DropColumn("dbo.ServSafes", "Store");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServSafes", "Store", c => c.String());
            AddColumn("dbo.ServSafes", "EmpName", c => c.String());
            AddColumn("dbo.HepAs", "EmpName", c => c.String());
            DropColumn("dbo.ServSafes", "EmpId");
            DropColumn("dbo.HepAs", "EmpId");
        }
    }
}
