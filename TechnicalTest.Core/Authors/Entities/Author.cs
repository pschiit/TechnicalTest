using TechnicalTest.Core.Authors.Events;
using TechnicalTest.Core.Guards;

namespace TechnicalTest.Core.Authors.Entities;

public sealed class Author : Aggregate
{
    public Author(Guid id, string name, string surname) : base(id) 
    {
        Guard.Against.NullOrEmpty(name, nameof(Name));
        Guard.Against.NullOrEmpty(surname, nameof(Surname));
        RegisterDomainEvent(new AuthorCreatedEvent(id, name, surname));
    }

    public string Name { get; private set; }
    public string Surname { get; private set; }

    internal void Apply(AuthorCreatedEvent @event)
    {
        Name = @event.Name;
        Surname = @event.Surname;
    }
}
