using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
        builder.Property(i => i.Category).IsRequired();
        builder.Property(i => i.Price).IsRequired();
        builder.Property(i => i.Amount).IsRequired();
        builder.OwnsOne(i => i.Category);
    }
}