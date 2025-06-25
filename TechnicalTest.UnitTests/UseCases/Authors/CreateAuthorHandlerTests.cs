using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Core.Exceptions;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.UseCases.Authors.Create;

namespace TechnicalTest.UnitTests.UseCases.Authors;

public class CreateAuthorHandlerTests
{
    private CreateAuthorHandler _handler = new CreateAuthorHandler(Substitute.For<IAggregateRepository<Author>>());

    private Author _author = new Author(Guid.NewGuid(), "author name", "author surname");

    [Fact]
    public async Task Handle_ReturnsGuid_GivenValidCommand()
    {
        var result = await _handler.Handle(
            new CreateAuthorCommand(
                _author.Name,
                _author.Surname),
            CancellationToken.None);

        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Handle_ReturnsFailed_GivenCommandWithoutName()
    {
        var act = async () => await _handler.Handle(
            new CreateAuthorCommand(
                "",
                _author.Surname),
            CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>().WithMessage("Required input 'Name' is missing.");
    }

    [Fact]
    public async Task Handle_ReturnsFailed_GivenCommandWithoutSurname()
    {
        var act = async () => await _handler.Handle(
            new CreateAuthorCommand(
                _author.Name,
                ""),
            CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>().WithMessage("Required input 'Surname' is missing.");
    }
}
