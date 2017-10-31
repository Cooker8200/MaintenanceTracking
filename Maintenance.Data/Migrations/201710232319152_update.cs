namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HepAs", "FirstShot", c => c.DateTime());
            AlterColumn("dbo.HepAs", "SecondShot", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HepAs", "SecondShot", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HepAs", "FirstShot", c => c.DateTime(nullable: false));
        }
    }
}
