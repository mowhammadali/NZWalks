using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Regions
{
    public class AddRegionRequest
    {
        [Display(Name = "Region Name")]
        [MaxLength(30, ErrorMessage = "The {0} must be less than {1} characters")]
        [Required(ErrorMessage = "An {0} is required")]
        public string RegionName { get; set; }

        [Display(Name = "Region Code")]
        [MaxLength(4, ErrorMessage = "The {0} must be less than {1} characters")]
        [Required(ErrorMessage = "An {0} is required")]
        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}