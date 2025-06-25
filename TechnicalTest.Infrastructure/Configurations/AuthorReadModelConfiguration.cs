using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechnicalTest.Core.Authors.ReadModels;

namespace TechnicalTest.Infrastructure.Configurations;

internal class AuthorReadModelConfiguration : IEntityTypeConfiguration<AuthorReadModel>
{
    public void Configure(EntityTypeBuilder<AuthorReadModel> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Surname).IsRequired();
    }
}
