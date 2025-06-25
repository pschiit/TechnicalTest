using TechnicalTest.Core;
using TechnicalTest.Core.Authors.ReadModels;

namespace TechnicalTest.UseCases.Posts;

public sealed record PostWithAuthorReadModel(Guid Id, AuthorReadModel Author, string Title, string Description, string Content)
    : ReadModel(Id);