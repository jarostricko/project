namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentsTest",
                c => new
                    {
                        StudentTestID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                        TestTemplate_TestTemplateID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentTestID)
                .ForeignKey("dbo.ApplicationUser", t => t.Student_Id)
                .ForeignKey("dbo.TestTemplate", t => t.TestTemplate_TestTemplateID)
                .Index(t => t.Student_Id)
                .Index(t => t.TestTemplate_TestTemplateID);
            
            CreateTable(
                "dbo.StudentAnswer",
                c => new
                    {
                        StudentAnswerID = c.Int(nullable: false, identity: true),
                        AnswerID = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        StudentsTest_StudentTestID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentAnswerID)
                .ForeignKey("dbo.Answer", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.StudentsTest", t => t.StudentsTest_StudentTestID)
                .Index(t => t.AnswerID)
                .Index(t => t.StudentsTest_StudentTestID);
            
            CreateTable(
                "dbo.TestViewModel",
                c => new
                    {
                        TestViewModelID = c.Int(nullable: false, identity: true),
                        TestTemplateName = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestViewModelID);
            
            AddColumn("dbo.Question", "TestViewModel_TestViewModelID", c => c.Int());
            CreateIndex("dbo.Question", "TestViewModel_TestViewModelID");
            AddForeignKey("dbo.Question", "TestViewModel_TestViewModelID", "dbo.TestViewModel", "TestViewModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "TestViewModel_TestViewModelID", "dbo.TestViewModel");
            DropForeignKey("dbo.StudentsTest", "TestTemplate_TestTemplateID", "dbo.TestTemplate");
            DropForeignKey("dbo.StudentAnswer", "StudentsTest_StudentTestID", "dbo.StudentsTest");
            DropForeignKey("dbo.StudentAnswer", "AnswerID", "dbo.Answer");
            DropForeignKey("dbo.StudentsTest", "Student_Id", "dbo.ApplicationUser");
            DropIndex("dbo.StudentAnswer", new[] { "StudentsTest_StudentTestID" });
            DropIndex("dbo.StudentAnswer", new[] { "AnswerID" });
            DropIndex("dbo.StudentsTest", new[] { "TestTemplate_TestTemplateID" });
            DropIndex("dbo.StudentsTest", new[] { "Student_Id" });
            DropIndex("dbo.Question", new[] { "TestViewModel_TestViewModelID" });
            DropColumn("dbo.Question", "TestViewModel_TestViewModelID");
            DropTable("dbo.TestViewModel");
            DropTable("dbo.StudentAnswer");
            DropTable("dbo.StudentsTest");
        }
    }
}
