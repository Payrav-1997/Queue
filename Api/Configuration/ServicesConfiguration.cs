using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.User;
using Service.Auth;

namespace Api.Configuration;

public class ServicesConfiguration
{
    private readonly IConfiguration _configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    public void Configure(IServiceCollection services)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddHttpClient();
        // ConfigureRedis(services);
        ConfigureModules(services);
        ConfigureCors(services);
        ConfigureDependencies(services);
       // ConfigureSignalR(services);
    }

    // private void ConfigureSignalR(IServiceCollection services)
    // {
    //     services.AddSignalR();
    // }

    private void ConfigureModules(IServiceCollection services)
    {
       // services.Configure<EmailSetting>(_configuration.GetSection("EmailSettings"));

        services.AddDbContext<DataContext>(builder =>
            builder.UseNpgsql(_configuration.GetConnectionString("PostgresConnectionString")));
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

    public IConfiguration GetConfig()
    {
        return _configuration;
    }
    
    private static void ConfigureDependencies(IServiceCollection service)
    {
        //Services
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IUserRepository, UserRepository>();
        
        
    }
}