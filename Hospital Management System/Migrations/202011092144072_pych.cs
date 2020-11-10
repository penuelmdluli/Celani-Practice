namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pych : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "PsychologistId", "dbo.Psychologists");
            DropIndex("dbo.Payments", new[] { "PsychologistId" });
            DropColumn("dbo.Payments", "PsychologistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PsychologistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "PsychologistId");
            AddForeignKey("dbo.Payments", "PsychologistId", "dbo.Psychologists", "Id", cascadeDelete: true);
        }
    }
}
