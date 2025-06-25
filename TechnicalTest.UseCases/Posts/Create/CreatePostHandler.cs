using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Guards;
using TechnicalTest.Core.Posts.Entities;
using TechnicalTest.Infrastructure.Guards;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Posts.Create;

public sealed class CreatePostHandler(IAggregateRepository<Post> _repository, IReadModelRepository<AuthorReadModel> _authorRepository)
    : ICommandHandler<CreatePostCommand, Guid>
{
    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        await Guard.Against.NotFoundAsync(_authorRepository, request.AuthorId, cancellationToken);
        var id = Guid.NewGuid();
        await _repository.InsertAsync(
            new Post(
                id,
                request.AuthorId,
                request.Title,
                request.Description,
                request.Content),
            cancellationToken);

        return id;
    }
}