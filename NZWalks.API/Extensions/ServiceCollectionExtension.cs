using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mapping;
using NZWalks.API.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IRegionRepository , RegionRepository>();
        services.AddScoped<IWalkRepository, WalkRepository>();

        return services;
    }

    public static IServiceCollection AddDbContextServices(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<NZWalksDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("NZWalksConnectionString"));
        });
        
        return services;
    }

    public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());
        
        return services;
    }
}