using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Core.Guards;
using TechnicalTest.Core.Posts.Events;

namespace TechnicalTest.Core.Posts.Entities;

public sealed class Post : Aggregate
{
    public Post(Guid id, Guid authorId, string title, string description, string content) : base(id)
    {
        Guard.Against.NullOrEmpty(id, nameof(Id));
        Guard.Against.NullOrEmpty(authorId, nameof(AuthorId));
        Guard.Against.NullOrEmpty(title, nameof(Title));
        Guard.Against.NullOrEmpty(description, nameof(Description));
        Guard.Against.NullOrEmpty(content, nameof(Content));
        RegisterDomainEvent(new PostCreatedEvent(id, authorId, title, description, content));
    }

    public Guid AuthorId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Content { get; private set; }

    internal void Apply(PostCreatedEvent @event)
    {
        AuthorId = @event.AuthorId;
        Title = @event.Title;
        Description = @event.Description;
        Content = @event.Content;
    }
}
