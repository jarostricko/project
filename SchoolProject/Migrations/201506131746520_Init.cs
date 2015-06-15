namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            AddColumn("dbo.Student", "StudentGroup_StudentGroupID", c => c.Int());
            CreateIndex("dbo.Student", "StudentGroup_StudentGroupID");
            AddForeignKey("dbo.Student", "StudentGroup_StudentGroupID", "dbo.StudentGroup", "StudentGroupID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "StudentGroup_StudentGroupID", "dbo.StudentGroup");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropIndex("dbo.Student", new[] { "StudentGroup_StudentGroupID" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropColumn("dbo.Student", "StudentGroup_StudentGroupID");
            DropTable("dbo.Answer");
        }
    }
}
