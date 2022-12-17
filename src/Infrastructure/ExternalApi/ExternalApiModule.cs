using DocumentGeneratorApp.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentGeneratorApp.Infrastructure.ExternalApi;

public static class ExternalApiModule
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IAddressDetailService, AddressDetailService>();
    }
}
