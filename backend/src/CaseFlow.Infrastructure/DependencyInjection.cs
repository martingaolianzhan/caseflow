using CaseFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaseFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCaseFlowPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Get the connection string from the configuration
        var connectionString = configuration.GetConnectionString("CaseFlow")
            ?? throw new InvalidOperationException(
                "Connection string 'CaseFlow' is not configured.");
        // Register the CaseFlowDbContext with the dependency injection container
        services.AddDbContext<CaseFlowDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
