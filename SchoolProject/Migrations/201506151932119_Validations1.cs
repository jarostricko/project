namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Question", "Explanation", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Explanation", c => c.String(maxLength: 150));
        }
    }
}
