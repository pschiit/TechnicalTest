using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Posts.Entities;

namespace TechnicalTest.UnitTests.Core.Posts;

public class PostTests
{
    [Fact]
    public void Constructor_ReturnAggregate_GivenValidParameters()
    {
        var test = new Post(Guid.NewGuid(), Guid.NewGuid(), "title", "description", "content");
        test.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_ThrowException_GivenEmptyGuid()
    {
        var act = () => new Post(Guid.Empty, Guid.NewGuid(), "title", "description", "content");
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_ThrowException_GivenEmptyAuthorGuid()
    {
        var act = () => new Post(Guid.NewGuid(), Guid.Empty, "title", "description", "content");
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_ThrowException_GivenNoTitle()
    {
        var act = () => new Post(Guid.NewGuid(), Guid.NewGuid(), "", "description", "content");
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_ThrowException_GivenNoDescription()
    {
        var act = () => new Post(Guid.NewGuid(), Guid.NewGuid(), "title", "", "content");
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_ThrowException_GivenNoContent()
    {
        var act = () => new Post(Guid.NewGuid(), Guid.NewGuid(), "title", "description", "");
        act.Should().Throw<DomainException>();
    }
}
