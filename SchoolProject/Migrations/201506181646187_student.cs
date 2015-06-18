namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            
            DropForeignKey("dbo.StudentStudentGroup", "Student_ID", "dbo.Student");
            DropIndex("dbo.StudentStudentGroup", new[] { "Student_ID" });
            
            DropPrimaryKey("dbo.StudentStudentGroup");
            AlterColumn("dbo.StudentStudentGroup", "Student_Id", c => c.String(nullable: false, maxLength: 128));
            
            AddPrimaryKey("dbo.StudentStudentGroup", new[] { "Student_Id", "StudentGroup_StudentGroupID" });
            CreateIndex("dbo.StudentStudentGroup", "Student_Id");
            AddForeignKey("dbo.StudentStudentGroup", "Student_Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsTeacher = c.Boolean(nullable: false),
                        SureName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.StudentStudentGroup", "Student_Id", "dbo.ApplicationUser");
            DropIndex("dbo.StudentStudentGroup", new[] { "Student_Id" });
            DropPrimaryKey("dbo.StudentStudentGroup");
            DropPrimaryKey("dbo.ApplicationUser");
            AlterColumn("dbo.StudentStudentGroup", "Student_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ApplicationUser", "SureName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ApplicationUser", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ApplicationUser", "Discriminator");
            DropColumn("dbo.ApplicationUser", "UserName");
            DropColumn("dbo.ApplicationUser", "AccessFailedCount");
            DropColumn("dbo.ApplicationUser", "LockoutEnabled");
            DropColumn("dbo.ApplicationUser", "LockoutEndDateUtc");
            DropColumn("dbo.ApplicationUser", "TwoFactorEnabled");
            DropColumn("dbo.ApplicationUser", "PhoneNumberConfirmed");
            DropColumn("dbo.ApplicationUser", "PhoneNumber");
            DropColumn("dbo.ApplicationUser", "SecurityStamp");
            DropColumn("dbo.ApplicationUser", "PasswordHash");
            DropColumn("dbo.ApplicationUser", "EmailConfirmed");
            DropColumn("dbo.ApplicationUser", "Email");
            DropColumn("dbo.ApplicationUser", "IsTeacher");
            AddPrimaryKey("dbo.StudentStudentGroup", new[] { "Student_ID", "StudentGroup_StudentGroupID" });
            AddPrimaryKey("dbo.ApplicationUser", "ID");
            CreateIndex("dbo.StudentStudentGroup", "Student_ID");
            AddForeignKey("dbo.StudentStudentGroup", "Student_ID", "dbo.Student", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.ApplicationUser", newName: "Student");
        }
    }
}
