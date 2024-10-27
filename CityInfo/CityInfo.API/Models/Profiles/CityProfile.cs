using AutoMapper;
using CityInfo.API.Controllers.Entities;

namespace CityInfo.API.Models.Profiles
{
   public class CityProfile : Profile
   {
      public CityProfile()
      {
         CreateMap<City, CityWithoutPointOfInterest>();
         CreateMap<City, CityDto>();
      }
   }
}