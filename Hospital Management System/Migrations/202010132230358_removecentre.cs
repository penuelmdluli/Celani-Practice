namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecentre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Centres", "Contact", c => c.String(nullable: false));
            AddColumn("dbo.Centres", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Centres", "Location");
            DropColumn("dbo.Centres", "Contact");
        }
    }
}
