using TechnicalTest.Core.Guards;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.Infrastructure.Guards;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Posts.Get
{
    public sealed class GetPostHandler(IReadModelRepository<PostReadModel> _repository)
        : IQueryHandler<GetPostQuery, PostReadModel>
    {
        public async Task<PostReadModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await Guard.Against.NotFoundAsync(_repository, request.PostId, cancellationToken);
        }
    }
}
