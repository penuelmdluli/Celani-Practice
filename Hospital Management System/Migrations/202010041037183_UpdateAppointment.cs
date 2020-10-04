namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "EndTime");
            DropColumn("dbo.Appointments", "StartTime");
        }
    }
}
