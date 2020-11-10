namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sgsff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Psychologists", "BloodGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Psychologists", "BloodGroup", c => c.String(nullable: false));
        }
    }
}
