using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Core.Exceptions;

namespace TechnicalTest.UnitTests.Core.Authors;

public class AuthorTests
{
    [Fact]
    public void Constructor_ReturnAggregate_GivenValidParameters()
    {
        var test = new Author(Guid.NewGuid(), "name", "surname");
        test.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_ThrowException_GivenEmptyGuid()
    {
        var act = () => new Author(Guid.Empty, "", "surname");
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_ThrowException_GivenNoName()
    {
        var act = () => new Author(Guid.NewGuid(), "", "surname");
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_ThrowException_GivenNoSurname()
    {
        var act = () => new Author(Guid.NewGuid(), "name", "");
        act.Should().Throw<DomainException>();
    }
}
