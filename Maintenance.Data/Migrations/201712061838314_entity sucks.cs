namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitysucks : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Stores", "StoreNumber", c => c.Int());
            //AlterColumn("dbo.Stores", "Phone", c => c.Int());
            //AlterColumn("dbo.Stores", "ZipCode", c => c.Int());
            //AlterColumn("dbo.Stores", "Supervisor", c => c.Int());
            //AlterColumn("dbo.Stores", "Otp", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Otp", c => c.Int(nullable: false));
            AlterColumn("dbo.Stores", "Supervisor", c => c.Int(nullable: false));
            AlterColumn("dbo.Stores", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Stores", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Stores", "StoreNumber", c => c.Int(nullable: false));
        }
    }
}
