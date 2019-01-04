namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profiles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "UserId", c => c.String());
        }
    }
}
