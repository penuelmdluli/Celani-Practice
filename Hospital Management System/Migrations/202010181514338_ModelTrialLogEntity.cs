namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelTrialLogEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditTrials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Who = c.String(nullable: false),
                        Transaction = c.String(nullable: false),
                        What = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditTrials");
        }
    }
}
