namespace TechnicalTest.Core.Posts.Events;

public sealed record PostCreatedEvent(Guid PostId, Guid AuthorId, string Title, string Description, string Content) : DomainEvent;
