namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbfkupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeesEmp",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
