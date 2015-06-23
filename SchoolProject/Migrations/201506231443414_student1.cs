namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.StudentsTest", new[] { "Student_Id" });
            DropColumn("dbo.StudentsTest", "StudentID");
            RenameColumn(table: "dbo.StudentsTest", name: "Student_Id", newName: "StudentID");
            AlterColumn("dbo.StudentsTest", "StudentID", c => c.String(maxLength: 128));
            CreateIndex("dbo.StudentsTest", "StudentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.StudentsTest", new[] { "StudentID" });
            AlterColumn("dbo.StudentsTest", "StudentID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.StudentsTest", name: "StudentID", newName: "Student_Id");
            AddColumn("dbo.StudentsTest", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentsTest", "Student_Id");
        }
    }
}
