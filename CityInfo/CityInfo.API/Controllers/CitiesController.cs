using CityInfo.API.Models;
using CItyInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterest>>> GetCities()
        {
            var citiesEntities = await _cityInfoRepository.GetCitiesAsync();

            var result = new List<CityWithoutPointOfInterest>();
            foreach (var cityEntity in citiesEntities)
            {
                result.Add(new CityWithoutPointOfInterest
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name,
                    Description = cityEntity.Description
                });
            }

            return Ok(result);
        }

        // [HttpGet("{id}")]
        // public ActionResult<CityDto> GetCity(int id)
        // {
        //     var CityToReturn = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);

        //     if (CityToReturn == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(CityToReturn);
        // }
    }
}