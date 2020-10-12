namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PsychologistId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        ServiceRecived = c.String(),
                        HoursOfService = c.Int(nullable: false),
                        ServiceAmount = c.Int(nullable: false),
                        PaidbyMedicalAid = c.Int(nullable: false),
                        PayByCash = c.Int(nullable: false),
                        TotalDue = c.Int(nullable: false),
                        InvoiceRefNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Psychologists", t => t.PsychologistId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.PsychologistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PsychologistId", "dbo.Psychologists");
            DropForeignKey("dbo.Payments", "PatientId", "dbo.Patients");
            DropIndex("dbo.Payments", new[] { "PsychologistId" });
            DropIndex("dbo.Payments", new[] { "PatientId" });
            DropTable("dbo.Payments");
        }
    }
}
