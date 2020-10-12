namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "ImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "ImageUrl");
        }
    }
}
