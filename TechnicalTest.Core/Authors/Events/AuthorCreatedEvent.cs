namespace TechnicalTest.Core.Authors.Events;

public sealed record AuthorCreatedEvent(Guid AuthorId, string Name, string Surname) : DomainEvent;
