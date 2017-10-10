namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HepA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HepA",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        FirstShot = c.DateTime(nullable: false),
                        SecondShot = c.DateTime(nullable: false),
                        Store = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HepA");
        }
    }
}
