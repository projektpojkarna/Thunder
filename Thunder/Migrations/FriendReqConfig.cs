namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class FriendReqConfig : DbMigrationsConfiguration<Thunder.Models.User.FriendRequestDbContext>
    {
        public FriendReqConfig()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Thunder.Models.User.FriendRequestDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
