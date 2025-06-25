using Microsoft.EntityFrameworkCore;
using TechnicalTest.Core;
using TechnicalTest.Infrastructure.Repositories.EventStore;

namespace TechnicalTest.Infrastructure.Repositories;

public class AggregateRepository<T>(BlogContext _context, IEventStore _eventStore) : IAggregateRepository<T>
    where T : Aggregate
{
    public async Task InsertAsync(T aggregate, CancellationToken cancellationToken = default)
    {
        await _eventStore.HandleEventsAsync(aggregate.Id, aggregate.GetType().Name, aggregate.DomainEvents);
        aggregate.ClearDomainEvents();
        await _context.SaveChangesAsync(cancellationToken);
    }
}
