namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "IsPaid");
        }
    }
}
