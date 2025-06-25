using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TechnicalTest.Core.Authors.Events;
using TechnicalTest.Core.Posts.Events;
using TechnicalTest.Infrastructure;
using TechnicalTest.UseCases.Authors.Create;
using TechnicalTest.UseCases.Authors.Get;
using TechnicalTest.UseCases.Posts.Create;
using TechnicalTest.UseCases.Posts.Get;

namespace TechnicalTest.UseCases;

public static class UseCasesServiceExtensions
{
    public static IServiceCollection AddUseCasesConfigs(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddInfrastructureConfigs(config);
        var mediatRAssemblies = new[]
        {
            Assembly.GetAssembly(typeof(CreateAuthorCommand)),
        };
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));

        return services;
    }
}
