namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "1StoreNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "1Address", c => c.String());
            AddColumn("dbo.Stores", "1Phone", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "1Email", c => c.String());
            AddColumn("dbo.Stores", "1City", c => c.String());
            AddColumn("dbo.Stores", "1State", c => c.String());
            AddColumn("dbo.Stores", "1ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "1Supervisor", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "1Otp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Otp");
            DropColumn("dbo.Stores", "Supervisor");
            DropColumn("dbo.Stores", "ZipCode");
            DropColumn("dbo.Stores", "State");
            DropColumn("dbo.Stores", "City");
            DropColumn("dbo.Stores", "Email");
            DropColumn("dbo.Stores", "Phone");
            DropColumn("dbo.Stores", "Address");
            DropColumn("dbo.Stores", "StoreNumber");
        }
    }
}
