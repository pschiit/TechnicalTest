using TechnicalTest.Core.Posts.ReadModels;

namespace TechnicalTest.UseCases.Posts.Get;

public sealed record GetPostWithAuthorQuery(Guid PostId)
    : IQuery<PostWithAuthorReadModel>;
