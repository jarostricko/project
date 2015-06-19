namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUser11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EditUserViewModel", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EditUserViewModel", "BirthDate");
        }
    }
}
