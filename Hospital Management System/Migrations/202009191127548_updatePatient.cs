namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "LevelOfEducation", c => c.String());
            AddColumn("dbo.Patients", "Language", c => c.String());
            AddColumn("dbo.Patients", "MaritalStatus", c => c.String());
            DropColumn("dbo.Patients", "BloodGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "BloodGroup", c => c.String());
            DropColumn("dbo.Patients", "MaritalStatus");
            DropColumn("dbo.Patients", "Language");
            DropColumn("dbo.Patients", "LevelOfEducation");
            DropColumn("dbo.Patients", "Age");
        }
    }
}
