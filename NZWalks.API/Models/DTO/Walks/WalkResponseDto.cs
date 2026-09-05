using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Difficulties;
using NZWalks.API.Models.DTO.Regions;

namespace NZWalks.API.Models.DTO.Walks;

public class WalkResponseDto
{
    public Guid Id { get; set; }
    public string WalkName { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }
    public string WalkImageUrl { get; set; }
    public RegionSummaryDto Region { get; set; }
    public DifficultyResponseDto Difficulty { get; set; }
}