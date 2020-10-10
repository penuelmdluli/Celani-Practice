namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Psychologist_Id", "dbo.Psychologists");
            DropIndex("dbo.Appointments", new[] { "Psychologist_Id" });
            AddColumn("dbo.Appointments", "ScheduleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ScheduleId");
            AddForeignKey("dbo.Appointments", "ScheduleId", "dbo.Schedules", "Id", cascadeDelete: true);
            DropColumn("dbo.Appointments", "DoctorId");
            DropColumn("dbo.Appointments", "Psychologist_Id");
            DropColumn("dbo.Schedules", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Status", c => c.String());
            AddColumn("dbo.Appointments", "Psychologist_Id", c => c.Int());
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.Appointments", new[] { "ScheduleId" });
            DropColumn("dbo.Appointments", "ScheduleId");
            CreateIndex("dbo.Appointments", "Psychologist_Id");
            AddForeignKey("dbo.Appointments", "Psychologist_Id", "dbo.Psychologists", "Id");
        }
    }
}
