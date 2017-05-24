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

            Country country1 = new Country { Id = 1, Name = "Switzerland" };
            Country country2 = new Country { Id = 2, Name = "France" };
            Country country3 = new Country { Id = 3, Name = "Italy" };

            Category category1 = new Category { Id = 1, Name = "Ski" };
            Category category2 = new Category { Id = 2, Name = "Snowboard" };
            Category category3 = new Category { Id = 3, Name = "Velo" };

            Client client1 = new Client { Id = 1, Country = country1, Firstname = "Patrick", Lastname = "Clivaz", Address = "Rue Pirredrittes 48, 3971 Chermignon", Phone = "078 776 00 97", Mail = "clivaz.patrick@icloud.com" };
            Client client2 = new Client { Id = 2, Country = country3, Firstname = "Daniel", Lastname = "De Girolamo", Address = "Rue du Forum 22, 1920 Martigny", Phone = "+41 76 822 60 29", Mail = "degirolamo.daniel@gmail.com" };
            Client client3 = new Client { Id = 3, Country = country2, Firstname = "Maxime", Lastname = "Bétrisey", Address = "Route du Plat de Chelin 9, 1978 Lens", Phone = "+41 79 900 56 29", Mail = "maxime.betrisey@cobwebsite.ch" };

            Material material1 = new Material { Id = 1, Category = category1, Name = "Atomic", Amount = 100 };
            Material material2 = new Material { Id = 2, Category = category2, Name = "Borealis", Amount = 50 };
            Material material3 = new Material { Id = 3, Category = category3, Name = "BMX", Amount = 50 };

            context.Categories.AddOrUpdate(x => x.Id,
                    category1, category2, category3);

            context.Clients.AddOrUpdate(x => x.Id,
                    client1, client2, client3);

            context.Countries.AddOrUpdate(x => x.Id,
                    country1, country2, country3);

            context.Materials.AddOrUpdate(x => x.Id,
                    material1, material2, material3);

            context.Rents.AddOrUpdate(x => x.Id,
                new Rent { Id = 1, Client = client1, Material = material1, BeginDate = new DateTime(2017, 11, 30), EndDate = new DateTime(2018, 04, 30) },
                new Rent { Id = 2, Client = client3, Material = material2, BeginDate = new DateTime(2017, 11, 15), EndDate = new DateTime(2018, 04, 30) },
                new Rent { Id = 3, Client = client2, Material = material3, BeginDate = new DateTime(2017, 12, 03), EndDate = new DateTime(2018, 04, 30) });
        }
    }
}
