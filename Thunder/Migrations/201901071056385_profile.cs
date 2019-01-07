namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "FirstName", c => c.String());
            AddColumn("dbo.Profiles", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "LastName");
            DropColumn("dbo.Profiles", "FirstName");
        }
    }
}
