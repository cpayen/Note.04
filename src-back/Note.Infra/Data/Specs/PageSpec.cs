using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Note.Core.Entities;

namespace Note.Infra.Data.Specs
{
    public class PageSpec
    {
        public PageSpec(EntityTypeBuilder<Page> entityBuilder)
        {
            EntitySpec<Page>.SetEntitySpecs(entityBuilder);

            entityBuilder
                .Property(o => o.Title)
                .IsRequired()
                .HasMaxLength(250);

            entityBuilder
                .Property(o => o.Slug)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder
                .HasIndex(o => o.Slug)
                .IsUnique();

            entityBuilder
                .Property(o => o.Description)
                .HasMaxLength(2000);

            entityBuilder
                .HasOne(o => o.Owner)
                .WithMany(o => o.Pages)
                .OnDelete(DeleteBehavior.SetNull);

            entityBuilder
                .HasOne(o => o.Space)
                .WithMany(o => o.Pages)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
