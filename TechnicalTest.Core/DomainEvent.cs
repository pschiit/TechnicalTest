using MediatR;

namespace TechnicalTest.Core;
public abstract record DomainEvent : INotification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedUtcDate { get; } = DateTime.UtcNow;
}