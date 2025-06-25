using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Core;
using TechnicalTest.Core.Authors.Entities;
using TechnicalTest.Core.Authors.Events;
using TechnicalTest.Infrastructure;
using TechnicalTest.Infrastructure.Repositories;
using TechnicalTest.Infrastructure.Repositories.EventStore;

namespace TechnicalTest.IntegrationTest.Infrastructure.Repositories;

public class EventStoreTests
{
    private BlogContext _context;
    private EventStore _eventStore;
    private ReadModelRepository<EventStream> _eventRepository;

    public EventStoreTests()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<BlogContext>()
                .UseSqlite(connection)
                .Options;

        _context = new BlogContext(options);
        _context.Database.EnsureCreated();

        _eventRepository = new ReadModelRepository<EventStream>(_context);
        _eventStore = new EventStore(_eventRepository, Substitute.For<IPublisher>());
    }

    [Fact]
    public async Task InsertAsync_CreateEventStreamWithAuthorCreatedEvent_GivenAuthor()
    {
        var author = new Author(Guid.NewGuid(), "name", "surname");
        await _eventStore.HandleEventsAsync(author.Id, author.GetType().Name, author.DomainEvents);
        _context.SaveChangesAsync(default);

        var result = _context.Set<EventStream>().First().Events.First();

        result.Should().NotBeNull();
        result.Should().BeOfType<AuthorCreatedEvent>();
        (result as AuthorCreatedEvent).AuthorId.Should().Be(author.Id);
    }
}