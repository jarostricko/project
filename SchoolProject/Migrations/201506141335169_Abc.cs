namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "StudentGroup_StudentGroupID", "dbo.StudentGroup");
            DropIndex("dbo.Student", new[] { "StudentGroup_StudentGroupID" });
            CreateTable(
                "dbo.StudentStudentGroup",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        StudentGroup_StudentGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.StudentGroup_StudentGroupID })
                .ForeignKey("dbo.Student", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroup_StudentGroupID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.StudentGroup_StudentGroupID);
            
            DropColumn("dbo.Student", "StudentGroup_StudentGroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "StudentGroup_StudentGroupID", c => c.Int());
            DropForeignKey("dbo.StudentStudentGroup", "StudentGroup_StudentGroupID", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentStudentGroup", "Student_ID", "dbo.Student");
            DropIndex("dbo.StudentStudentGroup", new[] { "StudentGroup_StudentGroupID" });
            DropIndex("dbo.StudentStudentGroup", new[] { "Student_ID" });
            DropTable("dbo.StudentStudentGroup");
            CreateIndex("dbo.Student", "StudentGroup_StudentGroupID");
            AddForeignKey("dbo.Student", "StudentGroup_StudentGroupID", "dbo.StudentGroup", "StudentGroupID");
        }
    }
}
