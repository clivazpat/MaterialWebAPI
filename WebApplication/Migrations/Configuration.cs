namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.Models.WebApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication.Models.WebApplicationContext context)
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

            Country country1 = new Country() { Id = 1, Name = "Switzerland" };
            Country country2 = new Country() { Id = 2, Name = "France" };
            Country country3 = new Country() { Id = 3, Name = "Italy" };

            Category category1 = new Category() { Id = 1, Name = "Ski" };
            Category category2 = new Category() { Id = 2, Name = "Snowboard" };
            Category category3 = new Category() { Id = 3, Name = "Velo" };

            context.Categories.AddOrUpdate(x => x.Id,
                category1, category2, category3);

            context.Clients.AddOrUpdate(x => x.Id,
        new Client() { Id = 1, Country = country1, Firstname = "Patrick", Lastname="Clivaz", Address="Rue Pirredrittes 48, 3971 Chermignon", Phone="078 776 00 97", Mail = "clivaz.patrick@icloud.com" },
        new Client() { Id = 2, Country = country3, Firstname = "Daniel", Lastname = "De Girolamo", Address = "Rue du Forum 22, 1920 Martigny", Phone = "+41 76 822 60 29", Mail = "degirolamo.daniel@gmail.com" },
        new Client() { Id = 3, Country = country2, Firstname = "Maxime", Lastname = "Bétrisey", Address = "Route du Plat de Chelin 9, 1978 Lens", Phone = "+41 79 900 56 29", Mail = "maxime.betrisey@cobwebsite.ch" });
        }
    }
}
