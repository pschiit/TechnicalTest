using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnicalTest.Infrastructure.Repositories.EventStore;

namespace TechnicalTest.Infrastructure.Configurations;

internal class EventStreamConfiguration : IEntityTypeConfiguration<EventStream>
{
    public void Configure(EntityTypeBuilder<EventStream> builder)
    {
        builder.Property(p => p.AggregateType).IsRequired();
    }
}