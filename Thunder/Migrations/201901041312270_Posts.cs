namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Posts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "UserId");
        }
    }
}
