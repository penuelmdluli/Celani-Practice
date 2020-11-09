namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "ServiceAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "PaidbyMedicalAid", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "PayByCash", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "TotalDue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "TotalDue", c => c.String());
            AlterColumn("dbo.Payments", "PayByCash", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "PaidbyMedicalAid", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "ServiceAmount", c => c.Int(nullable: false));
        }
    }
}
