namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updtePetentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "PatientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "PatientId");
        }
    }
}
