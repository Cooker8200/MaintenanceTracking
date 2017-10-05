namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaintenanceLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        VendorName = c.String(),
                        Invoice = c.Int(nullable: false),
                        RepairDetail = c.String(),
                        RepairType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MaintenanceLogs");
        }
    }
}
