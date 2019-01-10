namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class FriendConfig : DbMigrationsConfiguration<Thunder.Models.FriendsDbContext>
    {
        public FriendConfig()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Thunder.Models.FriendsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
