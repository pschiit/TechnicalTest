using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Guards;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.Infrastructure.Guards;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UseCases.Posts.Get
{
    public sealed class GetPostWithAuthorHandler(IReadModelRepository<PostReadModel> _repository, IReadModelRepository<AuthorReadModel> _authorRepository)
        : IQueryHandler<GetPostWithAuthorQuery, PostWithAuthorReadModel>
    {
        public async Task<PostWithAuthorReadModel> Handle(GetPostWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var post = await Guard.Against.NotFoundAsync(_repository, request.PostId, cancellationToken);
            var author = await Guard.Against.NotFoundAsync(_authorRepository, post.AuthorId, cancellationToken);

            return new PostWithAuthorReadModel(
                    post.Id,
                    author,
                    post.Title,
                    post.Description,
                    post.Content);

        }
    }
}
