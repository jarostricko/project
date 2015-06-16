namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Question", "Text", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Question", "Explanation", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Explanation", c => c.String());
            AlterColumn("dbo.Question", "Text", c => c.String());
        }
    }
}
