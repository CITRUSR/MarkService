using MarkService.Application.Contracts.ExternalServices.Student;
using MarkService.Infrastructure.ExternalServices.UserService.Student;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarkService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        AddGrpcClients(services, configuration);
        AddExternalServices(services);
        return services;
    }

    private static void AddGrpcClients(IServiceCollection services, IConfiguration configuration)
    {
        var badCertHttpClientHandler = new HttpClientHandler();

        badCertHttpClientHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        AddUsersApi(services, configuration, badCertHttpClientHandler);
    }

    private static void AddUsersApi(
        IServiceCollection services,
        IConfiguration configuration,
        HttpClientHandler? httpClientHandler = null
    )
    {
        var apiUrl = configuration["MicroServices:UsersAPI"];

        if (string.IsNullOrEmpty(apiUrl))
        {
            throw new InvalidOperationException("userAPI url is not set");
        }

        services
            .AddGrpcClient<UserServiceClient.StudentService.StudentServiceClient>(cfg =>
            {
                cfg.Address = new Uri(apiUrl);
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return httpClientHandler ?? new HttpClientHandler();
            });
    }

    private static void AddExternalServices(IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
    }
}
