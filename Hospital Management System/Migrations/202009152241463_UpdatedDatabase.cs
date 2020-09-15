namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Centres");
            DropForeignKey("dbo.Psychologists", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Psychologists", new[] { "DepartmentId" });
            AddColumn("dbo.Psychologists", "Centre_Id", c => c.Int());
            CreateIndex("dbo.Psychologists", "Centre_Id");
            AddForeignKey("dbo.Psychologists", "Centre_Id", "dbo.Centres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Psychologists", "Centre_Id", "dbo.Centres");
            DropIndex("dbo.Psychologists", new[] { "Centre_Id" });
            DropColumn("dbo.Psychologists", "Centre_Id");
            CreateIndex("dbo.Psychologists", "DepartmentId");
            AddForeignKey("dbo.Psychologists", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Centres", newName: "Departments");
        }
    }
}
