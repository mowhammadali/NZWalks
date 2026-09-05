using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Walks;

namespace NZWalks.API.Models.DTO.Regions
{
    public class RegionResponseDto
    {
        public Guid Id { get; set; }
        public string RegionName { get; set; }
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
        public ICollection<WalkSummaryDto> Walks { get; set; }
    }
}