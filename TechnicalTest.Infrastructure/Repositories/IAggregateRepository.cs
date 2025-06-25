using TechnicalTest.Core;

namespace TechnicalTest.Infrastructure.Repositories;

public interface IAggregateRepository<T> where T : Aggregate
{
    Task InsertAsync(T entity, CancellationToken cancellationToken = default);
}
