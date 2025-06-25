using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Infrastructure;
using TechnicalTest.Infrastructure.Repositories;

namespace TechnicalTest.IntegrationTest.Infrastructure.Repositories;

public class ReadModelRepositoryTests
{
    private BlogContext _context;
    private ReadModelRepository<AuthorReadModel> _repository;

    public ReadModelRepositoryTests()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<BlogContext>()
                .UseSqlite(connection)
                .Options;

        _context = new BlogContext(options);
        _context.Database.EnsureCreated();
        _repository = new ReadModelRepository<AuthorReadModel>(_context);
    }

    [Fact]
    public async Task GetAsync_ReturnNull_GivenUnknownId()
    {
        var result = await _repository.GetAsync(Guid.Empty);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAsync_ReturnAuthor_GivenExistingId()
    {
        var author = new AuthorReadModel(Guid.NewGuid(), "name", "surname");
        await _context.Set<AuthorReadModel>().AddAsync(author);

        var result = await _repository.GetAsync(author.Id);

        result.Should().NotBeNull();
        result.Id.Should().Be(author.Id);
        result.Name.Should().Be(author.Name);
        result.Surname.Should().Be(author.Surname);
    }

    [Fact]
    public async Task Insert_PopulateContext_GivenAuthor()
    {
        var author = new AuthorReadModel(Guid.NewGuid(), "name", "surname");
        _repository.Insert(author);

        var result = await _context.Set<AuthorReadModel>().FindAsync([author.Id], default);

        result.Should().NotBeNull();
        result.Id.Should().Be(author.Id);
        result.Name.Should().Be(author.Name);
        result.Surname.Should().Be(author.Surname);
    }
}
