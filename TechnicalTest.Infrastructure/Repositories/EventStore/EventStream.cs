using Microsoft.Extensions.Logging;
using TechnicalTest.Core;

namespace TechnicalTest.Infrastructure.Repositories.EventStore;

public sealed record EventStream(Guid Id, string AggregateType) : ReadModel(Id)
{
    public List<DomainEvent> Events { get; init; } = [];
}
