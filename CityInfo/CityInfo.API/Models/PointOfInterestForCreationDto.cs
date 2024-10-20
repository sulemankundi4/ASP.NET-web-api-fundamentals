using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50, ErrorMessage = "The name shouldn't have more than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should provide a description value.")]
        [MaxLength(200, ErrorMessage = "The description shouldn't have more than 200 characters.")]
        public string Description { get; set; }
    }
}