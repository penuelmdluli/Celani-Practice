namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consultation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PsychologistId = c.Int(nullable: false),
                        ConsultationDate = c.DateTime(),
                        TreatmentPlan = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Psychologists", t => t.PsychologistId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.PsychologistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "PsychologistId", "dbo.Psychologists");
            DropForeignKey("dbo.Consultations", "PatientId", "dbo.Patients");
            DropIndex("dbo.Consultations", new[] { "PsychologistId" });
            DropIndex("dbo.Consultations", new[] { "PatientId" });
            DropTable("dbo.Consultations");
        }
    }
}
