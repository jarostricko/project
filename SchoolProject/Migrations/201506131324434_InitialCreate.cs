namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Points = c.Int(nullable: false),
                        Explanation = c.String(),
                        ThematicFieldID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.ThematicField", t => t.ThematicFieldID, cascadeDelete: true)
                .Index(t => t.ThematicFieldID);
            
            CreateTable(
                "dbo.ThematicField",
                c => new
                    {
                        ThematicFieldID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ThematicFieldID);
            
            CreateTable(
                "dbo.StudentGroup",
                c => new
                    {
                        StudentGroupID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.StudentGroupID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SureName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SureName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TestTemplate",
                c => new
                    {
                        TestTemplateID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time = c.Time(nullable: false, precision: 7),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        QuestionCount = c.Int(nullable: false),
                        StudentGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestTemplateID)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroupID, cascadeDelete: true)
                .Index(t => t.StudentGroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestTemplate", "StudentGroupID", "dbo.StudentGroup");
            DropForeignKey("dbo.Question", "ThematicFieldID", "dbo.ThematicField");
            DropIndex("dbo.TestTemplate", new[] { "StudentGroupID" });
            DropIndex("dbo.Question", new[] { "ThematicFieldID" });
            DropTable("dbo.TestTemplate");
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.ThematicField");
            DropTable("dbo.Question");
        }
    }
}
