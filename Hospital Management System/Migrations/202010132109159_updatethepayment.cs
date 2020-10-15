namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatethepayment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Payments", "FirstName");
            DropColumn("dbo.Payments", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "LastName", c => c.String());
            AddColumn("dbo.Payments", "FirstName", c => c.String());
        }
    }
}
