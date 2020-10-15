namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymenchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PatientAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PatientAddress");
        }
    }
}
