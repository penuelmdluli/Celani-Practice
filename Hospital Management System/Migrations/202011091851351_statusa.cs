namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AppointmentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "AppointmentStatus");
        }
    }
}
