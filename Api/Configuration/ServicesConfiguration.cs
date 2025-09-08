using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.City;
using Repository.Region;
using Repository.User;
using Service.Auth;
using Service.City;
using Service.Region;

namespace Api.Configuration;

public class ServicesConfiguration(IConfiguration configuration)
{
    public void Configure(IServiceCollection services)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
       // services.AddHttpClient();
        // ConfigureRedis(services);
        ConfigureModules(services);
        ConfigureCors(services);
        ConfigureDependencies(services);
       // ConfigureSignalR(services);
       services.AddControllers();
    }

    // private void ConfigureSignalR(IServiceCollection services)
    // {
    //     services.AddSignalR();
    // }

    private void ConfigureModules(IServiceCollection services)
    {
       // services.Configure<EmailSetting>(_configuration.GetSection("EmailSettings"));

        services.AddDbContext<DataContext>(builder =>
            builder.UseNpgsql(configuration.GetConnectionString("PostgresConnectionString")));
    }

    // private void ConfigureRedis(IServiceCollection services)
    // {
    //     var redisString = _configuration["RedisConnectionString"]!;
    //     var redisConfigurationOptions = ConfigurationOptions.Parse(redisString);
    //
    //     services.AddStackExchangeRedisCache(redisCacheConfig =>
    //     {
    //         redisCacheConfig.ConfigurationOptions = redisConfigurationOptions;
    //     });
    //
    //     services.AddDataProtection()
    //         .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(redisConfigurationOptions))
    //         .SetApplicationName(redisString);
    // }

    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("_corsOrigins",
                policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
        });

    }
    
    private static void ConfigureDependencies(IServiceCollection service)
    {
        
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<ICityRepository, CityRepository>();
        service.AddScoped<IRegionRepository, RegionRepository>();
        
        
        //Services
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<ICityService, CityService>();
        service.AddScoped<IRegionService, RegionService>();
    }
}