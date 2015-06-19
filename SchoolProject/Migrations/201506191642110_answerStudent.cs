namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answerStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "AnsweredByStudent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answer", "AnsweredByStudent");
        }
    }
}
