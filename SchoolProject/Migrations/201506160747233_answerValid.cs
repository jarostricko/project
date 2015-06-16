namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answerValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answer", "AnswerText", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answer", "AnswerText", c => c.String());
        }
    }
}
