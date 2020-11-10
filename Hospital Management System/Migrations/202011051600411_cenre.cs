namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cenre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Centres", "Contact", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Centres", "Contact", c => c.String(nullable: false));
        }
    }
}
