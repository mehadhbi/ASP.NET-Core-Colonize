using Colonize.Website.Data.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Colonize.Website.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Voyage> Voyage { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ships = new List<Ship>
            {
                 new Ship(1, "Moonshot", "Lorem ipsum dolor", 200,
                new Uri("https://via.placeholder.com/480x360.png?text=Moonshot", UriKind.Absolute)),

                 new Ship(2, "Mars Explorer", "Lorem ipsum dolor", 2800,
                new Uri("https://via.placeholder.com/480x360.png?text=Mars+Explorer", UriKind.Absolute))
            };

            /*  foreach (var ship in ships)
              {
                  modelBuilder.Entity<Ship>().HasData(ship);
              } */

            ships.ForEach(x => modelBuilder.Entity<Ship>().HasData(x));
            // ships.ForEach(ship => modelBuilder.Entity<Ship>().HasData(ship)); // Likadant som ovan, ship istället för x

            var destinations = new List<Destination>
            {
                 new Destination(1, "Moon", "Lorem ipsum dolor",
                new Uri("https://via.placeholder.com/480x360.png?text=Moon", UriKind.Absolute)),

                 new Destination(2, "Mars", "Lorem ipsum dolor",
                new Uri("https://via.placeholder.com/480x360.png?text=Mars", UriKind.Absolute))
            };

            destinations.ForEach(x => modelBuilder.Entity<Destination>().HasData(x));

            var moonshot = ships.Find(x => x.Name == "Moonshot");
            var marsExplorer = ships.Find(x => x.Name == "Mars Explorer");

            var moon = destinations.Find(x => x.Name == "Moon");
            var mars = destinations.Find(x => x.Name == "Mars");

            var voyages = new List<Voyage>
            {
                new Voyage(id: 1, moon.Id, moonshot.Id, new DateTime(2024, 6, 4), new DateTime(2024, 6, 8)),
                new Voyage(id: 2, mars.Id, marsExplorer.Id,  new DateTime(2028, 12, 1), new DateTime(2029, 2, 1))
            };

            voyages.ForEach(x => modelBuilder.Entity<Voyage>().HasData(x));
        }
    }
}
