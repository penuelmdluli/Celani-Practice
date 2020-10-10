namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "ScheduleDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "StartDate");
            DropColumn("dbo.Schedules", "EndDate");
            DropColumn("dbo.Schedules", "TimePerPatient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "TimePerPatient", c => c.String(nullable: false));
            AddColumn("dbo.Schedules", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "ScheduleDate");
        }
    }
}
