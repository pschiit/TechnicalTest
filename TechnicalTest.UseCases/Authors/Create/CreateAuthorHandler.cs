using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Authors.Create;

public sealed class CreateAuthorHandler(IAggregateRepository<Author> _repository)
    : ICommandHandler<CreateAuthorCommand, Guid>
{
    public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        await _repository.InsertAsync(
            new Author(
                id,
                request.Name,
                request.Surname),
            cancellationToken);

        return id;
    }
}