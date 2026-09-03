using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Regions
{
    public class UpdateRegionRequest
    {
        [Display(Name = "Region Name")]
        [StringLength(40 , ErrorMessage = "The {0} must be less than {1}")]
        [Required(ErrorMessage = "An {0} is required")]
        public string Name { get; set; }
        [Display(Name = "Region Code")]
        [StringLength(10, ErrorMessage = "The {0} must be less than {1}")]
        [Required(ErrorMessage = "An {0} is required")]
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
