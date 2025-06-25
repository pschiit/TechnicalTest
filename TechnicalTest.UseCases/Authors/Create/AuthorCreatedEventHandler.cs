using MediatR;
using Microsoft.Extensions.Logging;
using TechnicalTest.Core.Authors.Events;
using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Authors.Create;

public sealed class AuthorCreatedEventHandler(IReadModelRepository<AuthorReadModel> _repository, ILogger<AuthorCreatedEventHandler> _logger)
    : INotificationHandler<AuthorCreatedEvent>
{
    public Task Handle(AuthorCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating AuthorReadModel");
        _repository.Insert(
            new AuthorReadModel(
                notification.AuthorId,
                notification.Name,
                notification.Surname));
        return Task.CompletedTask;
    }
}
