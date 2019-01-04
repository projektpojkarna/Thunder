namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Location", c => c.String());
            AddColumn("dbo.Profiles", "Occupation", c => c.String());
            AddColumn("dbo.Profiles", "ImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "ImgPath");
            DropColumn("dbo.Profiles", "Occupation");
            DropColumn("dbo.Profiles", "Location");
        }
    }
}
