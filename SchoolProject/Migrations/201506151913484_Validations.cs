namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answer", "AnswerText", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Question", "Text", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Question", "Explanation", c => c.String(maxLength: 150));
            AlterColumn("dbo.TestTemplate", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StudentGroup", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Student", "SureName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ThematicField", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teacher", "SureName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teacher", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teacher", "FirstName", c => c.String());
            AlterColumn("dbo.Teacher", "SureName", c => c.String());
            AlterColumn("dbo.ThematicField", "Title", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            AlterColumn("dbo.Student", "SureName", c => c.String());
            AlterColumn("dbo.StudentGroup", "Title", c => c.String());
            AlterColumn("dbo.TestTemplate", "Name", c => c.String());
            AlterColumn("dbo.Question", "Explanation", c => c.String());
            AlterColumn("dbo.Question", "Text", c => c.String());
            AlterColumn("dbo.Answer", "AnswerText", c => c.String());
        }
    }
}
