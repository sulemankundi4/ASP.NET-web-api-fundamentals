using CityInfo.API.Controllers.Entities;

namespace CItyInfo.API.Services
{
   public interface ICityInfoRepository
   {
      // IQueryable<City> GetCities();
      Task<IEnumerable<City>> GetCitiesAsync();

      Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);

      Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int cityId);

      Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);

      Task<bool> CityExistsAsync(int cityId);
   }
}