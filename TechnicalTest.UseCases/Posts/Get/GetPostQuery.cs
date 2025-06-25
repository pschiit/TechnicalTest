using TechnicalTest.Core.Posts.ReadModels;

namespace TechnicalTest.UseCases.Posts.Get;

public sealed record GetPostQuery(Guid PostId)
    : IQuery<PostReadModel>;
