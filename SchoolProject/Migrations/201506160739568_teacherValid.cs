namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherValid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teacher", "SureName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teacher", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teacher", "FirstName", c => c.String());
            AlterColumn("dbo.Teacher", "SureName", c => c.String());
        }
    }
}
