using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Exceptions;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.UseCases.Authors.Get;

namespace TechnicalTest.UnitTests.UseCases.Authors;

public class GetAuthorHandlerTests
{
    private GetAuthorHandler _handler;
    private readonly IReadModelRepository<AuthorReadModel> _authorRepository = Substitute.For<IReadModelRepository<AuthorReadModel>>();

    private AuthorReadModel _author = new (Guid.NewGuid(), "author name", "author surname");

    public GetAuthorHandlerTests()
    {
        _authorRepository.GetAsync(Arg.Is(_author.Id), Arg.Any<CancellationToken>()).Returns(Task.FromResult(_author));
        _handler = new GetAuthorHandler(_authorRepository);
    }

    [Fact]
    public async Task Handle_ReturnsSuccess_GivenValidId()
    {
        var result = await _handler.Handle(
            new GetAuthorQuery(_author.Id),
            CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(_author.Id);
    }

    [Fact]
    public async Task Handle_ReturnsError_GivenUnknowId()
    {
        var authorId = Guid.NewGuid();
        var act = async () => await _handler.Handle(
            new GetAuthorQuery(authorId),
            CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"AuthorReadModel not found: {authorId}");
    }
}
