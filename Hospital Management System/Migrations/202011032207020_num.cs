namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class num : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "PhoneNo", c => c.String(maxLength: 10));
            AlterColumn("dbo.Patients", "Contact", c => c.String(maxLength: 10));
            AlterColumn("dbo.Psychologists", "PhoneNo", c => c.String(maxLength: 10));
            AlterColumn("dbo.Psychologists", "ContactNo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Psychologists", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Psychologists", "PhoneNo", c => c.String());
            AlterColumn("dbo.Patients", "Contact", c => c.String());
            AlterColumn("dbo.Patients", "PhoneNo", c => c.String());
        }
    }
}
