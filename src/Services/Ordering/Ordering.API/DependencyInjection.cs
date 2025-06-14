namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        // Configure API-specific middleware, if any
        return app;
    }
}
