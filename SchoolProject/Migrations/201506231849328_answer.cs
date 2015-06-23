namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentAnswer", "StudentsTest_StudentTestID", "dbo.StudentsTest");
            DropIndex("dbo.StudentAnswer", new[] { "StudentsTest_StudentTestID" });
            CreateTable(
                "dbo.StudentAnswerStudentsTest",
                c => new
                    {
                        StudentAnswer_StudentAnswerID = c.Int(nullable: false),
                        StudentsTest_StudentTestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentAnswer_StudentAnswerID, t.StudentsTest_StudentTestID })
                .ForeignKey("dbo.StudentAnswer", t => t.StudentAnswer_StudentAnswerID, cascadeDelete: true)
                .ForeignKey("dbo.StudentsTest", t => t.StudentsTest_StudentTestID, cascadeDelete: true)
                .Index(t => t.StudentAnswer_StudentAnswerID)
                .Index(t => t.StudentsTest_StudentTestID);
            
            DropColumn("dbo.StudentAnswer", "StudentsTest_StudentTestID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAnswer", "StudentsTest_StudentTestID", c => c.Int());
            DropForeignKey("dbo.StudentAnswerStudentsTest", "StudentsTest_StudentTestID", "dbo.StudentsTest");
            DropForeignKey("dbo.StudentAnswerStudentsTest", "StudentAnswer_StudentAnswerID", "dbo.StudentAnswer");
            DropIndex("dbo.StudentAnswerStudentsTest", new[] { "StudentsTest_StudentTestID" });
            DropIndex("dbo.StudentAnswerStudentsTest", new[] { "StudentAnswer_StudentAnswerID" });
            DropTable("dbo.StudentAnswerStudentsTest");
            CreateIndex("dbo.StudentAnswer", "StudentsTest_StudentTestID");
            AddForeignKey("dbo.StudentAnswer", "StudentsTest_StudentTestID", "dbo.StudentsTest", "StudentTestID");
        }
    }
}
