namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPsychologistTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Doctors", newName: "Psychologists");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Schedules", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropIndex("dbo.Schedules", new[] { "DoctorId" });
            AddColumn("dbo.Appointments", "Psychologist_Id", c => c.Int());
            AddColumn("dbo.Prescriptions", "Psychologist_Id", c => c.Int());
            AddColumn("dbo.Schedules", "Psychologist_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "Psychologist_Id");
            CreateIndex("dbo.Prescriptions", "Psychologist_Id");
            CreateIndex("dbo.Schedules", "Psychologist_Id");
            AddForeignKey("dbo.Appointments", "Psychologist_Id", "dbo.Psychologists", "Id");
            AddForeignKey("dbo.Prescriptions", "Psychologist_Id", "dbo.Psychologists", "Id");
            AddForeignKey("dbo.Schedules", "Psychologist_Id", "dbo.Psychologists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "Psychologist_Id", "dbo.Psychologists");
            DropForeignKey("dbo.Prescriptions", "Psychologist_Id", "dbo.Psychologists");
            DropForeignKey("dbo.Appointments", "Psychologist_Id", "dbo.Psychologists");
            DropIndex("dbo.Schedules", new[] { "Psychologist_Id" });
            DropIndex("dbo.Prescriptions", new[] { "Psychologist_Id" });
            DropIndex("dbo.Appointments", new[] { "Psychologist_Id" });
            DropColumn("dbo.Schedules", "Psychologist_Id");
            DropColumn("dbo.Prescriptions", "Psychologist_Id");
            DropColumn("dbo.Appointments", "Psychologist_Id");
            CreateIndex("dbo.Schedules", "DoctorId");
            CreateIndex("dbo.Prescriptions", "DoctorId");
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Schedules", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Psychologists", newName: "Doctors");
        }
    }
}
