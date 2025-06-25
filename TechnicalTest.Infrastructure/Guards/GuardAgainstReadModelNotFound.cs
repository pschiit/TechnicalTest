using TechnicalTest.Core;
using TechnicalTest.Core.Guards;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.Infrastructure.Guards;
public static partial class GuardAgainstReadModelNotFound
{
    public async static Task<T> NotFoundAsync<T>(
        this IGuardClause guardClause, 
        IReadModelRepository<T> repository, 
        Guid id, 
        CancellationToken cancellationToken, 
        string? message = null)
        where T : ReadModel
        => Guard.Against.NotFound(
                await repository.GetAsync(id, cancellationToken),
                $"{typeof(T).Name} not found: {id}");
}