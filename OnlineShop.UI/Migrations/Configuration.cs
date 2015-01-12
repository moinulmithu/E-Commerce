namespace OnlineShop.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OnlineShop.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.UI.Infrastructure.EcommerceContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineShop.UI.Infrastructure.EcommerceContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(
                c => c.CategoryName,
                new Category() { CategoryName = "Mobile"},
                new Category() { CategoryName = "Computer"},
                new Category() { CategoryName = "Camera"}
                );
        }
    }
}
