namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propic_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Image");
        }
    }
}
