using AutoMapper;
using CityInfo.API.Controllers.Entities;

namespace CityInfo.API.Models.Profiles
{
   public class PointOfInterestProfile : Profile
   {
      public PointOfInterestProfile()
      {
         CreateMap<PointOfInterest, PointOfInterestDto>();
      }
   }
}