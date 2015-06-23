namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAnswer", "StudentsTestID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentAnswer", "StudentsTestID");
        }
    }
}
