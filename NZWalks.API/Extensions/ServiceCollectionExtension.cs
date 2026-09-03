using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

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
}