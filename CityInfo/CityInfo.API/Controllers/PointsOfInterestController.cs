using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using CityInfo.API.Services;
using AutoMapper;
using CItyInfo.API.Services;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]

    public class PointOfInterestController : ControllerBase
    {

        private readonly ILogger<PointOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly ICityInfoRepository _cityInfoRepository;

        public PointOfInterestController(ILogger<PointOfInterestController> logger, IMailService mailService, IMapper mapper, ICityInfoRepository cityInfoRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }
            var pointOfInterestForCity = await _cityInfoRepository.GetPointOfInterestsForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointOfInterestForCity));
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointofinterestid)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointofinterestid);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        // [HttpPost]
        // public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        // {
        //     //if (!ModelState.IsValid)
        //     //{
        //     //    return BadRequest(ModelState);
        //     //}

        //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

        //     if (city == null)
        //     {
        //         return NotFound();
        //     }

        //     var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(c => c.PointOfInterest).Max(p => p.Id);

        //     var finalPointOfInterest = new PointOfInterestDto()
        //     {
        //         Id = ++maxPointOfInterestId,
        //         Name = pointOfInterest.Name,
        //         Description = pointOfInterest.Description
        //     };

        //     city.PointOfInterest.Add(finalPointOfInterest);

        //     return CreatedAtRoute("GetPointOfInterest", new { cityId, pointofinterestid = finalPointOfInterest.Id }, finalPointOfInterest);
        // }

        // [HttpPut("{pointofinterestid}")]
        // public ActionResult UpdatePointOfInterest(int cityId, int pointofinterestid, PointOfInterestForUpdateDto pointOfInterest)
        // {
        //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //     if (city == null)
        //     {
        //         return NotFound();
        //     }

        //     var pointOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == pointofinterestid);
        //     if (pointOfInterestFromStore == null)
        //     {
        //         return NotFound();
        //     }

        //     pointOfInterestFromStore.Name = pointOfInterest.Name;
        //     pointOfInterestFromStore.Description = pointOfInterest.Description;

        //     return NoContent();
        // }

        // [HttpPatch("{pointofinterestid}")]
        // public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointofinterestid, JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        // {
        //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //     if (city == null)
        //     {
        //         return NotFound();
        //     }

        //     var pointOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == pointofinterestid);
        //     if (pointOfInterestFromStore == null)
        //     {
        //         return NotFound();
        //     }

        //     var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
        //     {
        //         Name = pointOfInterestFromStore.Name,
        //         Description = pointOfInterestFromStore.Description
        //     };

        //     patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (!TryValidateModel(pointOfInterestToPatch))
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        //     pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

        //     return NoContent();
        // }

        // [HttpDelete("{pointofinterestid}")]
        // public ActionResult DeletePointOfInterest(int cityId, int pointofinterestid)
        // {
        //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //     if (city == null)
        //     {
        //         return NotFound();
        //     }

        //     var pointOfInterestFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == pointofinterestid);
        //     if (pointOfInterestFromStore == null)
        //     {
        //         return NotFound();
        //     }


        //     city.PointOfInterest.Remove(pointOfInterestFromStore);

        //     _mailService.Send("Point of interest deleted.", $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");

        //     return NoContent();
        // }
    }
}