using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnicalTest.Core.Posts.ReadModels;

namespace TechnicalTest.Infrastructure.Configurations;

internal class PostReadModelConfiguration : IEntityTypeConfiguration<PostReadModel>
{
    public void Configure(EntityTypeBuilder<PostReadModel> builder)
    {
        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Content).IsRequired();
        builder.HasIndex(p => p.AuthorId);
    }
}
