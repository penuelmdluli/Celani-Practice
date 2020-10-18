namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuditLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuditTrials", "Where", c => c.String(nullable: false));
            AddColumn("dbo.AuditTrials", "When", c => c.DateTime(nullable: false));
            DropColumn("dbo.AuditTrials", "What");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuditTrials", "What", c => c.DateTime(nullable: false));
            DropColumn("dbo.AuditTrials", "When");
            DropColumn("dbo.AuditTrials", "Where");
        }
    }
}
