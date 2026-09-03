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
            Name = addRegionRequest.Name,
            Code = addRegionRequest.Code,
            RegionImageUrl = addRegionRequest.RegionImageUrl,
        };
    }

    public static Region MapToRegion(this UpdateRegionRequest updateRegionRequest, Guid id)
    {
        return new Region()
        {
            Id = id,
            Name = updateRegionRequest.Name,
            Code = updateRegionRequest.Code,
            RegionImageUrl = updateRegionRequest.RegionImageUrl,
        };
    }

    public static RegionResponseDto MapToResponse(this Region region)
    {
        return new RegionResponseDto()
        {
            Id = region.Id,
            Name = region.Name,
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