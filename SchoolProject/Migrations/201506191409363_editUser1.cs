namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUser1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditUserViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FirstName = c.String(),
                        SureName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EditUserViewModel");
        }
    }
}
