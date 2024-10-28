using CityInfo.API.Controllers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DBContext
{
   public class CityInfoContext : DbContext
   {
      public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<City>().HasData(
             new City("New York City") { Id = 1, Description = "The one with that big park." },
             new City("Antwerp") { Id = 2, Description = "The one with the cathedral that was never really finished." },
             new City("Paris") { Id = 3, Description = "The one with that big tower." },
             new City("Tokyo") { Id = 4, Description = "The one with the busy crossing." },
             new City("Sydney") { Id = 5, Description = "The one with the famous opera house." },
             new City("London") { Id = 6, Description = "The one with the big clock tower." },
             new City("Berlin") { Id = 7, Description = "The one with the historic wall." },
             new City("Rome") { Id = 8, Description = "The one with the ancient ruins." },
             new City("Moscow") { Id = 9, Description = "The one with the colorful domes." },
             new City("Rio de Janeiro") { Id = 10, Description = "The one with the big statue." }
         );

         modelBuilder.Entity<PointOfInterest>().HasData(
             new PointOfInterest("Central Park point of interest for new York city") { Id = 1, CityId = 1 },
             new PointOfInterest("Empire State Building") { Id = 2, CityId = 1 },
             new PointOfInterest("Statue of Liberty") { Id = 3, CityId = 1 },
             new PointOfInterest("Cathedral of Our Lady") { Id = 4, CityId = 2 },
             new PointOfInterest("Antwerp Central Station") { Id = 5, CityId = 2 },
             new PointOfInterest("Tokyo Tower") { Id = 6, CityId = 3 },
             new PointOfInterest("Meiji Shrine") { Id = 7, CityId = 3 },
             new PointOfInterest("Sydney Opera House") { Id = 8, CityId = 5 },
             new PointOfInterest("Sydney Harbour Bridge") { Id = 9, CityId = 5 },
             new PointOfInterest("Big Ben") { Id = 10, CityId = 6 },
             new PointOfInterest("British Museum") { Id = 11, CityId = 6 },
             new PointOfInterest("The Berlin Wall") { Id = 12, CityId = 7 },
             new PointOfInterest("The Brandenburg Gate") { Id = 13, CityId = 7 },
             new PointOfInterest("The Colosseum") { Id = 14, CityId = 8 },
             new PointOfInterest("The Pantheon") { Id = 15, CityId = 8 },
             new PointOfInterest("St. Basil's Cathedral") { Id = 16, CityId = 9 },
             new PointOfInterest("The Kremlin") { Id = 17, CityId = 9 },
             new PointOfInterest("Christ the Redeemer") { Id = 18, CityId = 10 },
             new PointOfInterest("Sugarloaf Mountain") { Id = 19, CityId = 10 }
         );
      }

      public DbSet<City> Cities { get; set; }
      public DbSet<PointOfInterest> PointOfInterests { get; set; }
   }
}