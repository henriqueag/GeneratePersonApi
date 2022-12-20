namespace DocumentGeneratorApp.Api.Extensions;

/// <summary>
/// Extensões para interface IServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registras os serviços configurados no método ConfigureServices de cada módulo
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        DomainModule.ConfigureServices(services);
        EntityFrameworkCoreModule.ConfigureServices(services, configuration);
        ExternalApiModule.ConfigureServices(services);
    }
}