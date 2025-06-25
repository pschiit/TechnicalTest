using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.UseCases.Posts.Get;

namespace TechnicalTest.UnitTests.UseCases.Posts;

public class GetPostWithAuthorHandlerTests
{
    private GetPostWithAuthorHandler _handler;
    private readonly IReadModelRepository<PostReadModel> _postRepository = Substitute.For<IReadModelRepository<PostReadModel>>();
    private readonly IReadModelRepository<AuthorReadModel> _authorRepository = Substitute.For<IReadModelRepository<AuthorReadModel>>();

    private AuthorReadModel _author = new (Guid.NewGuid(), "author name", "author surname");
    private PostReadModel _post;

    public GetPostWithAuthorHandlerTests()
    {
        _post = new (Guid.NewGuid(), _author.Id, "title", "description", "content");
        _postRepository.GetAsync(Arg.Is(_post.Id), Arg.Any<CancellationToken>()).Returns(Task.FromResult(_post));
        _authorRepository.GetAsync(Arg.Is(_author.Id), Arg.Any<CancellationToken>()).Returns(Task.FromResult(_author));
        _handler = new GetPostWithAuthorHandler(_postRepository, _authorRepository);
    }

    [Fact]
    public async Task Handle_ReturnsSuccess_GivenValidId()
    {
        var result = await _handler.Handle(
            new GetPostWithAuthorQuery(_post.Id),
            CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(_post.Id);
        result.Author.Id.Should().Be(_author.Id);
    }

    [Fact]
    public async Task Handle_ReturnsError_GivenUnknowId()
    {
        var postId = Guid.NewGuid();
        var act = async () => await _handler.Handle(
            new GetPostWithAuthorQuery(postId),
            CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"PostReadModel not found: {postId}");
    }

    [Fact]
    public async Task Handle_ReturnsError_GivenUnknowAuthorId()
    {
        var authorId = Guid.NewGuid();
        var post = new PostReadModel(Guid.NewGuid(), authorId, "title", "description", "content");
        _postRepository.GetAsync(Arg.Is(post.Id), Arg.Any<CancellationToken>()).Returns(Task.FromResult(post));

        var act = async () => await _handler.Handle(
            new GetPostWithAuthorQuery(post.Id),
            CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"AuthorReadModel not found: {authorId}");
    }
}
