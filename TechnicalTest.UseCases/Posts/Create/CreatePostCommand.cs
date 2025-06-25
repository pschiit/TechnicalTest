namespace TechnicalTest.UseCases.Posts.Create;

public sealed record CreatePostCommand(Guid AuthorId, string Title, string Description, string Content)
    : ICommand<Guid>;