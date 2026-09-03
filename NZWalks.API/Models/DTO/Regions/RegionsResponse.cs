using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO.Regions;

public class RegionsResponse
{
    public IEnumerable<RegionResponseDto> Items { get; set; } =  new List<RegionResponseDto>();
}