using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Guards;
using TechnicalTest.Infrastructure.Guards;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Authors.Get
{
    public sealed class GetAuthorHandler(IReadModelRepository<AuthorReadModel> _repository)
        : IQueryHandler<GetAuthorQuery, AuthorReadModel>
    {
        public async Task<AuthorReadModel> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return await Guard.Against.NotFoundAsync(_repository, request.AuthorId, cancellationToken);
        }
    }
}
