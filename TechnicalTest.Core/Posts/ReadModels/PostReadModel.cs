namespace TechnicalTest.Core.Posts.ReadModels;

public sealed record PostReadModel(Guid Id, Guid AuthorId, string Title, string Description, string Content)
    :ReadModel(Id);