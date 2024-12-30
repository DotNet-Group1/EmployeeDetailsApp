namespace EmployeeDetailsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImageAndResume : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "profileImage", c => c.String());
            AddColumn("dbo.Teachers", "resume", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "resume");
            DropColumn("dbo.Teachers", "profileImage");
        }
    }
}
