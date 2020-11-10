namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookedid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "BookedPsychologistId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "BookedPsychologistId");
        }
    }
}
