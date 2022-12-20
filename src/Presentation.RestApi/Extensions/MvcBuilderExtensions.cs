using Microsoft.Extensions.DependencyInjection;

namespace DocumentGeneratorApp.Presentation.RestApi.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddClasslibPart(this IMvcBuilder builder)
    {
        return builder.AddApplicationPart(typeof(MvcBuilderExtensions).Assembly);
    }
}
