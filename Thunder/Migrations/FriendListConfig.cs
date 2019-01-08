namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class FriendListConfig : DbMigrationsConfiguration<Thunder.Models.FriendListDbContext>
    {
        public FriendListConfig()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Thunder.Models.FriendListDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
