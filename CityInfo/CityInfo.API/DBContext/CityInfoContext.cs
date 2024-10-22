using CityInfo.API.Controllers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CItyInfo.API.DBContext
{
   public class CityInfoContext : DbContext
   {
      public DbSet<City> Cities { get; set; }
      public DbSet<PointOfInterest> PointOfInterests { get; set; }
   }
}