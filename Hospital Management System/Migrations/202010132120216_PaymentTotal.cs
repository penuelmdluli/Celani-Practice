namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTotal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "TotalDue", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "TotalDue", c => c.Int(nullable: false));
        }
    }
}
