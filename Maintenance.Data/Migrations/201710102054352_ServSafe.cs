namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServSafe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServSafes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        Proctor = c.String(),
                        Expiration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServSafes");
        }
    }
}
