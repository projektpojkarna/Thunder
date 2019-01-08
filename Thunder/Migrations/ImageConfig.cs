namespace Thunder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ImageConfig : DbMigrationsConfiguration<Thunder.Models.User.ImageDbContext>
    {
        public ImageConfig()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Thunder.Models.User.ImageDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
