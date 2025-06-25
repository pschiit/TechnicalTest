using TechnicalTest.Core;

namespace TechnicalTest.Infrastructure.Repositories.EventStore;

public interface IEventStore
{
    Task HandleEventsAsync(Guid id, string aggregateType, IEnumerable<DomainEvent> events);
}
