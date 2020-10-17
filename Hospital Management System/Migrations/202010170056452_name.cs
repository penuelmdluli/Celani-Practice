namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "PsychologistName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "PsychologistName");
        }
    }
}
