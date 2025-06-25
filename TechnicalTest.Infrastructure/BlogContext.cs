using Microsoft.EntityFrameworkCore;
using TechnicalTest.Core.Authors.Events;
using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.Core.Posts.Events;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.Infrastructure.Repositories.EventStore;

namespace TechnicalTest.Infrastructure;

public sealed class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<PostReadModel> PostReadModels { get; set; }
    public DbSet<AuthorReadModel> AuthorReadModels { get; set; }
    public DbSet<EventStream> EventStreams { get; set; }
    public DbSet<AuthorCreatedEvent> AuthorCreatedEvents { get; set; }
    public DbSet<PostCreatedEvent> PostCreatedEvents { get; set; }
}
