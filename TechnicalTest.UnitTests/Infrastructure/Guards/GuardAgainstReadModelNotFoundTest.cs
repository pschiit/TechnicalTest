using TechnicalTest.Core;
using TechnicalTest.Core.Exceptions;
using TechnicalTest.Core.Guards;
using TechnicalTest.Infrastructure.Guards;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.UnitTests.Infrastructure.Guards;

public class GuardAgainstReadModelNotFoundTest
{
    private readonly IReadModelRepository<ReadModel> _repository = Substitute.For<IReadModelRepository<ReadModel>>();
    ReadModel _readModel = Substitute.For<ReadModel>(Guid.NewGuid());

    public GuardAgainstReadModelNotFoundTest()
    {
        _repository.GetAsync(Arg.Is(_readModel.Id), Arg.Any<CancellationToken>()).Returns(_readModel);
    }

    [Fact]
    public async Task NotFound_ThrowException_GivenUnknownId()
    {
        Guid id = Guid.NewGuid();
        var act = () => Guard.Against.NotFoundAsync(_repository, id, default);
        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"ReadModel not found: {id}");
    }

    [Fact]
    public async Task NotFound_ReturnReadModel_GivenExistingId()
    {
        var result = await Guard.Against.NotFoundAsync(_repository, _readModel.Id, default);
        result.Id.Should().Be(_readModel.Id);
    }
}
