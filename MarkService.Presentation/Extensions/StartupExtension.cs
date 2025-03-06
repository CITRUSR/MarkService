using MarkService.Application;
using MarkService.Infrastructure;

namespace MarkService.Presentation.Extensions;

public static class StartupExtension
{
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        return builder;
    }

    public static WebApplication ConfigureApp(this WebApplication app)
    {
        return app;
    }
}
