using DocumentGeneratorApp.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentGeneratorApp.Infrastructure.EntityFrameworkCore;

public static class EntityFrameworkCoreModule
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IPersonRepository, PersonRepository>();
    }
}