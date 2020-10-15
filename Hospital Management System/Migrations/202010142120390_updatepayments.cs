namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepayments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PatientName", c => c.String());
            AddColumn("dbo.Payments", "PatientNumber", c => c.String());
            AddColumn("dbo.Payments", "PatientEmail", c => c.String());
            AddColumn("dbo.Payments", "PatientGender", c => c.String());
            AddColumn("dbo.Payments", "PsychologistName", c => c.String());
            AddColumn("dbo.Payments", "PsychologistSpecialist", c => c.String());
            AddColumn("dbo.Payments", "PsychologistContact", c => c.String());
            AddColumn("dbo.Payments", "CentreContact", c => c.String());
            AddColumn("dbo.Payments", "CentrLocation", c => c.String());
            AddColumn("dbo.Payments", "CenterName", c => c.String());
            AddColumn("dbo.Payments", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "DateOfBirth");
            DropColumn("dbo.Payments", "CenterName");
            DropColumn("dbo.Payments", "CentrLocation");
            DropColumn("dbo.Payments", "CentreContact");
            DropColumn("dbo.Payments", "PsychologistContact");
            DropColumn("dbo.Payments", "PsychologistSpecialist");
            DropColumn("dbo.Payments", "PsychologistName");
            DropColumn("dbo.Payments", "PatientGender");
            DropColumn("dbo.Payments", "PatientEmail");
            DropColumn("dbo.Payments", "PatientNumber");
            DropColumn("dbo.Payments", "PatientName");
        }
    }
}
