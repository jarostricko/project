namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacher : DbMigration
    {
        public override void Up()
        {
            
            DropTable("dbo.Teacher");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropPrimaryKey("dbo.ApplicationUser");
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
            AddPrimaryKey("dbo.ApplicationUser", "ID");
            RenameTable(name: "dbo.ApplicationUser", newName: "Teacher");
        }
    }
}
