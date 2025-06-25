using MediatR;
using TechnicalTest.Core;

namespace TechnicalTest.Infrastructure.Repositories.EventStore;

public class EventStore(IReadModelRepository<EventStream> _repository, IPublisher _mediator) : IEventStore
{
    public async Task HandleEventsAsync(Guid id, string aggregateType, IEnumerable<DomainEvent> events)
    {
        await DispatchEventsAsync(events);
        var eventStream = await _repository.GetAsync(id);

        if (eventStream == null)
        {
            eventStream = new EventStream(id, aggregateType);
            _repository.Insert(eventStream);
        }
        eventStream.Events.AddRange(events);
    }
    private async Task DispatchEventsAsync(IEnumerable<DomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}
