using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.Infrastructure.Repositories.EventStore;

namespace TechnicalTest.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureConfigs(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddDbContext<BlogContext>(options 
            => options.UseSqlite(
                config.GetConnectionString("SqliteConnection"), 
                x => x.MigrationsAssembly("TechnicalTest.Api")));

        services.AddScoped(typeof(IReadModelRepository<>), typeof(ReadModelRepository<>));
        services.AddScoped(typeof(IAggregateRepository<>), typeof(AggregateRepository<>));
        services.TryAddTransient<IEventStore, EventStore>();

        return services;
    }
}
