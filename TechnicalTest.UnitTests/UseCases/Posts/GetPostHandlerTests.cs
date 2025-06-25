using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.UseCases.Posts.Get;

namespace TechnicalTest.UnitTests.UseCases.Posts;

public class GetPostHandlerTests
{
    private GetPostHandler _handler;
    private readonly IReadModelRepository<PostReadModel> _postRepository = Substitute.For<IReadModelRepository<PostReadModel>>();

    private PostReadModel _post = new (Guid.NewGuid(), Guid.NewGuid(), "title", "description", "content");

    public GetPostHandlerTests()
    {
        _postRepository.GetAsync(Arg.Is(_post.Id), Arg.Any<CancellationToken>()).Returns(Task.FromResult(_post));
        _handler = new GetPostHandler(_postRepository);
    }

    [Fact]
    public async Task Handle_ReturnsSuccess_GivenValidId()
    {
        var result = await _handler.Handle(
            new GetPostQuery(_post.Id),
            CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(_post.Id);
    }

    [Fact]
    public async Task Handle_ReturnsError_GivenUnknowId()
    {
        var postId = Guid.NewGuid();
        var act = async () => await _handler.Handle(
            new GetPostQuery(postId),
            CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"PostReadModel not found: {postId}");
    }
}
