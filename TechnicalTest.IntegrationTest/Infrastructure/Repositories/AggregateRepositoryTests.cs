using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Core.Authors.Events;
using TechnicalTest.Infrastructure;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.Infrastructure.Repositories.EventStore;

namespace TechnicalTest.IntegrationTest.Infrastructure.Repositories;

public class AggregateRepositoryTests
{
    private BlogContext _context;
    private AggregateRepository<Author> _repository;
    private EventStore _eventStore;
    private ReadModelRepository<EventStream> _eventRepository;

    public AggregateRepositoryTests()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<BlogContext>()
                .UseSqlite(connection)
                .Options;

        _context = new BlogContext(options);
        _context.Database.EnsureCreated();

        _eventRepository = new ReadModelRepository<EventStream>(_context);
        var publisher = Substitute.For<IPublisher>();

        _eventStore = new EventStore(_eventRepository, publisher);
        _repository = new AggregateRepository<Author>(_context, _eventStore);
    }

    [Fact]
    public async Task InsertAsync_CreateEventStreamWithAuthorCreatedEvent_GivenAuthor()
    {
        var author = new Author(Guid.NewGuid(), "name", "surname");
        await _repository.InsertAsync(author);

        var result = _context.Set<EventStream>().First().Events.First();

        result.Should().NotBeNull();
        result.Should().BeOfType<AuthorCreatedEvent>();
        (result as AuthorCreatedEvent).AuthorId.Should().Be(author.Id);
    }
}
