namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateteDatabse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ambulances", "AmbulanceDriverId", "dbo.AmbulanceDrivers");
            DropIndex("dbo.Ambulances", new[] { "AmbulanceDriverId" });
            DropTable("dbo.AmbulanceDrivers");
            DropTable("dbo.Ambulances");
            DropTable("dbo.Medicines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ambulances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AmbulanceId = c.String(nullable: false),
                        AmbulanceStatus = c.String(),
                        AmbulanceDriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AmbulanceDrivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Cnic = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Ambulances", "AmbulanceDriverId");
            AddForeignKey("dbo.Ambulances", "AmbulanceDriverId", "dbo.AmbulanceDrivers", "Id", cascadeDelete: true);
        }
    }
}
