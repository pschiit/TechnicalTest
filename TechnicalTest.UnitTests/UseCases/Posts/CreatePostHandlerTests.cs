using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Posts.Entities;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.UseCases.Posts.Create;

namespace TechnicalTest.UnitTests.UseCases.Posts;

public class CreatePostHandlerTests
{
    private readonly IAggregateRepository<Post> _postRepository = Substitute.For<IAggregateRepository<Post>>();
    private readonly IReadModelRepository<AuthorReadModel> _authorRepository = Substitute.For<IReadModelRepository<AuthorReadModel>>();
    private CreatePostHandler _handler;
    
    private AuthorReadModel _author = new (Guid.NewGuid(), "author name", "author surname");
    private Post _post;

    public CreatePostHandlerTests()
    {
        _post = new Post(Guid.NewGuid(), _author.Id, "title", "description", "content");
        _authorRepository.GetAsync(Arg.Is(_author.Id), Arg.Any<CancellationToken>()).Returns(Task.FromResult(_author));
        _handler = new CreatePostHandler(_postRepository, _authorRepository);
    }

    [Fact]
    public async Task Handle_ReturnsGuid_GivenValidCommand()
    {
        var result = await _handler.Handle(
            new CreatePostCommand(
                _post.AuthorId,
                _post.Title,
                _post.Description,
                _post.Content),
            CancellationToken.None);

        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Handle_ReturnsFailed_GivenCommandWithoutAuthorId()
    {
        var authorId = Guid.Empty;
        var act = async () => await _handler.Handle(
            new CreatePostCommand(
                authorId,
                _post.Title,
                _post.Description,
                _post.Content),
            CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"AuthorReadModel not found: {authorId}");
    }

    [Fact]
    public async Task Handle_ReturnsFailed_GivenCommandWithoutTitle()
    {
        var act = async () => await _handler.Handle(
            new CreatePostCommand(
                _post.AuthorId,
                "",
                _post.Description,
                _post.Content),
            CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>().WithMessage("Required input 'Title' is missing.");
    }

    [Fact]
    public async Task Handle_ReturnsFailed_GivenCommandWithoutDescription()
    {
        var act = async () => await _handler.Handle(
            new CreatePostCommand(
                _post.AuthorId,
                _post.Title,
                "",
                _post.Content),
            CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>().WithMessage("Required input 'Description' is missing.");
    }

    [Fact]
    public async Task Handle_ReturnsFailed_GivenCommandWithoutContent()
    {
        var act = async () => await _handler.Handle(
            new CreatePostCommand(
                _post.AuthorId,
                _post.Title,
                _post.Description,
                ""),
            CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>().WithMessage("Required input 'Content' is missing.");
    }
}
