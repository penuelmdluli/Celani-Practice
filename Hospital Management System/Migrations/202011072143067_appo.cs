namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "CompletedStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "CompletedStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "CompletedStatus");
            DropColumn("dbo.Appointments", "CompletedStatus");
        }
    }
}
