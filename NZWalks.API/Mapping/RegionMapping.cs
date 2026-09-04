using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions;

namespace NZWalks.API.Mapping;

public static class RegionMapping
{
    public static Region MapToRegion(this AddRegionRequest addRegionRequest)
    {
        return new Region()
        {
            Id = Guid.NewGuid(),
            Name = addRegionRequest.RegionName,
            Code = addRegionRequest.Code,
            RegionImageUrl = addRegionRequest.RegionImageUrl,
        };
    }

    public static Region MapToRegion(this UpdateRegionRequest updateRegionRequest, Guid id)
    {
        return new Region()
        {
            Id = id,
            Name = updateRegionRequest.RegionName,
            Code = updateRegionRequest.Code,
            RegionImageUrl = updateRegionRequest.RegionImageUrl,
        };
    }

    public static RegionResponseDto MapToResponse(this Region region)
    {
        return new RegionResponseDto()
        {
            Id = region.Id,
            RegionName = region.Name,
            Code = region.Code,
            RegionImageUrl = region.RegionImageUrl,
        };
    }

    public static RegionsResponse MapToResponse(this IEnumerable<Region> regions)
    {
        return new RegionsResponse()
        {
            Items = regions.Select(r => r.MapToResponse())
        };
    }
}