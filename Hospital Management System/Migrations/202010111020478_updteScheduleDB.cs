namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updteScheduleDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "IsBooked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "IsBooked");
        }
    }
}
