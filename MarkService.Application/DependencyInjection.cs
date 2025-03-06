using Microsoft.Extensions.DependencyInjection;

namespace MarkService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
