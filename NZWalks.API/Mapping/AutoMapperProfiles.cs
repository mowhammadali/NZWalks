using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Difficulties;
using NZWalks.API.Models.DTO.Regions;
using NZWalks.API.Models.DTO.Walks;

namespace NZWalks.API.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Region Mapper
        CreateMap<Region, RegionResponseDto>().ForMember(
                dest => dest.RegionName,
                opt => opt.MapFrom(src => src.Name)
            )
            .ReverseMap();

        CreateMap<Region, RegionSummaryDto>().ForMember(
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


        // Walk Mapper
        CreateMap<Walk, WalkResponseDto>()
            .ForMember(
                dest => dest.WalkName,
                opt => opt.MapFrom(src => src.Name)
            ).ReverseMap();

        CreateMap<Walk, WalkSummaryDto>()
            .ForMember(
                dest => dest.WalkName,
                opt => opt.MapFrom(src => src.Name)
            ).ReverseMap();

        CreateMap<Walk, AddWalkRequestDto>()
            .ForMember(
                dest => dest.WalkName,
                opt => opt.MapFrom(src => src.Name)
            ).ReverseMap();

        CreateMap<IEnumerable<Walk>, WalksResponseDto>()
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src)
            ).ForMember(
                dest => dest.TotalCount,
                opt => opt.MapFrom(src => src.Count())
            );


        // Difficulty Mapper
        CreateMap<Difficulty, DifficultyResponseDto>()
            .ForMember(
                dest => dest.DifficultyName,
                opt => opt.MapFrom(src => src.Name)
            ).ReverseMap();
    }
}