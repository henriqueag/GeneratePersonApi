using Microsoft.Extensions.DependencyInjection;

namespace DocumentGeneratorApp.Domain;

public static class DomainModule
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IDocumentGenerator, DocumentGenerator>();
        services.AddTransient<IDocumentValidator, DocumentValidator>();
        services.AddTransient<IPersonInformation, PersonInformation>();
        services.AddTransient<IPersonService, PersonService>();
    }
}
