using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Guards;
using TechnicalTest.Core.Posts.Entities;

namespace TechnicalTest.UnitTests.Core.Guards;

public class GuardAgainstNotFoundExtensionsTests
{
    [Fact]
    public void NotFound_ThrowException_GivenNull()
    {
        Post test = null;
        var act = () => Guard.Against.NotFound(test);
        act.Should().Throw<NotFoundException>().WithMessage("not found");
    }

    [Fact]
    public void NotFound_ReturnObject_GivenObject()
    {
        var test = new object();
        Guard.Against.NotFound(test).Should().Be(test);
    }
}
