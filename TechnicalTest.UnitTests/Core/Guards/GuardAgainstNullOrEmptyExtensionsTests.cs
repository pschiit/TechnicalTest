using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Guards;


namespace TechnicalTest.UnitTests.Core.Guards
{
    public class GuardAgainstNullOrEmptyExtensionsTests
    {
        [Fact]
        public void NullOrEmpty_ThrowException_GivenNull()
        {
            string? test = null;
            var act = () => Guard.Against.NullOrEmpty(test);
            act.Should().Throw<DomainException>();
        }

        [Fact]
        public void NullOrEmpty_ThrowException_GivenEmptyString()
        {
            string test = "";
            var act = () => Guard.Against.NullOrEmpty(test);
            act.Should().Throw<DomainException>().WithMessage("Required input 'value' is missing.");
        }

        [Fact]
        public void NullOrEmpty_ReturnString_GivenValidString()
        {
            string test = "not empty";
            Guard.Against.NullOrEmpty(test).Should().Be(test);
        }

        [Fact]
        public void NullOrEmpty_ThrowException_GivenEmptyGuid()
        {
            Guid test = Guid.Empty;
            var act = () => Guard.Against.NullOrEmpty(test);
            act.Should().Throw<DomainException>().WithMessage("Required input 'value' is missing.");
        }

        [Fact]
        public void NullOrEmpty_ReturnGuid_GivenValidGuid()
        {
            Guid test = Guid.NewGuid();
            Guard.Against.NullOrEmpty(test).Should().Be(test);
        }
    }
}
