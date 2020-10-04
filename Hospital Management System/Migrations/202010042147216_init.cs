namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "PersonId", "dbo.Consultations");
            DropForeignKey("dbo.FilePaths", "PersonID", "dbo.Consultations");
            DropIndex("dbo.Files", new[] { "PersonId" });
            DropIndex("dbo.FilePaths", new[] { "PersonID" });
            DropTable("dbo.Consultations");
            DropTable("dbo.Files");
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.FilePaths", "PersonID");
            CreateIndex("dbo.Files", "PersonId");
            AddForeignKey("dbo.FilePaths", "PersonID", "dbo.Consultations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Files", "PersonId", "dbo.Consultations", "ID", cascadeDelete: true);
        }
    }
}
