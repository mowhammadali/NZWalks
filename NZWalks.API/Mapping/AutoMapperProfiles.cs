using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Regions;

namespace NZWalks.API.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Region Mapper
        CreateMap<Region, RegionResponseDto>().ForMember(
            dest => dest.RegionName,
            opt => opt.MapFrom(src => src.Name)
            ).ReverseMap();

        CreateMap<IEnumerable<Region>, RegionsResponse>()
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src)
            );

        CreateMap<Region, AddRegionRequest>().ForMember(
            dest => dest.RegionName,
            opt => opt.MapFrom(src => src.Name)
            ).ReverseMap();
        
        CreateMap<Region, UpdateRegionRequest>().ForMember(
            dest => dest.RegionName,
            opt => opt.MapFrom(src => src.Name)
        ).ReverseMap();
    }
}