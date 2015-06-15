namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abcd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestTemplateQuestion",
                c => new
                    {
                        TestTemplate_TestTemplateID = c.Int(nullable: false),
                        Question_QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestTemplate_TestTemplateID, t.Question_QuestionID })
                .ForeignKey("dbo.TestTemplate", t => t.TestTemplate_TestTemplateID, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_QuestionID, cascadeDelete: true)
                .Index(t => t.TestTemplate_TestTemplateID)
                .Index(t => t.Question_QuestionID);
            
            CreateTable(
                "dbo.ThematicFieldTestTemplate",
                c => new
                    {
                        ThematicField_ThematicFieldID = c.Int(nullable: false),
                        TestTemplate_TestTemplateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ThematicField_ThematicFieldID, t.TestTemplate_TestTemplateID })
                .ForeignKey("dbo.ThematicField", t => t.ThematicField_ThematicFieldID, cascadeDelete: true)
                .ForeignKey("dbo.TestTemplate", t => t.TestTemplate_TestTemplateID, cascadeDelete: true)
                .Index(t => t.ThematicField_ThematicFieldID)
                .Index(t => t.TestTemplate_TestTemplateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThematicFieldTestTemplate", "TestTemplate_TestTemplateID", "dbo.TestTemplate");
            DropForeignKey("dbo.ThematicFieldTestTemplate", "ThematicField_ThematicFieldID", "dbo.ThematicField");
            DropForeignKey("dbo.TestTemplateQuestion", "Question_QuestionID", "dbo.Question");
            DropForeignKey("dbo.TestTemplateQuestion", "TestTemplate_TestTemplateID", "dbo.TestTemplate");
            DropIndex("dbo.ThematicFieldTestTemplate", new[] { "TestTemplate_TestTemplateID" });
            DropIndex("dbo.ThematicFieldTestTemplate", new[] { "ThematicField_ThematicFieldID" });
            DropIndex("dbo.TestTemplateQuestion", new[] { "Question_QuestionID" });
            DropIndex("dbo.TestTemplateQuestion", new[] { "TestTemplate_TestTemplateID" });
            DropTable("dbo.ThematicFieldTestTemplate");
            DropTable("dbo.TestTemplateQuestion");
        }
    }
}
