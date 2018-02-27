using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfoApi.Model
{
    public class CreatePointOfInteresDto
    {
        public CreatePointOfInteresDto()
        {
        }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(10, ErrorMessage = "Name should not be longer than 10 letters")]
        public string Name { get; set; }
        [MaxLength(60, ErrorMessage = "Description must not exceed 50 characters")]
        public string Description { get; set; }
    }
}
