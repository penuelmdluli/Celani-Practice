namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultationFiles", "Consultation_Id", "dbo.Consultations");
            DropIndex("dbo.ConsultationFiles", new[] { "Consultation_Id" });
            DropTable("dbo.ConsultationFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConsultationFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Consultation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ConsultationFiles", "Consultation_Id");
            AddForeignKey("dbo.ConsultationFiles", "Consultation_Id", "dbo.Consultations", "Id");
        }
    }
}
