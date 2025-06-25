using MediatR;
using Microsoft.Extensions.Logging;
using TechnicalTest.Core.Posts.Events;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Posts.Create;

public sealed class PostCreatedEventHandler(IReadModelRepository<PostReadModel> _repository, ILogger<PostCreatedEventHandler> _logger)
    : INotificationHandler<PostCreatedEvent>
{
    public async Task Handle(PostCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating PostReadModel");
        _repository.Insert(
            new PostReadModel(
                notification.PostId,
                notification.AuthorId,
                notification.Title,
                notification.Description,
                notification.Content));
    }
}
