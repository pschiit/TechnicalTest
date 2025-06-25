using TechnicalTest.Core.Authors.ReadModels;

namespace TechnicalTest.UseCases.Authors.Get;

public sealed record GetAuthorQuery(Guid AuthorId)
    : IQuery<AuthorReadModel>;
