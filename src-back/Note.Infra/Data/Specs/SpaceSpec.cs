using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Note.Core.Entities;

namespace Note.Infra.Data.Specs
{
    public class SpaceSpec
    {
        public SpaceSpec(EntityTypeBuilder<Space> entityBuilder)
        {
            EntitySpec<Space>.SetEntitySpecs(entityBuilder);

            entityBuilder
                .Property(o => o.Name)
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
                .Property(o => o.Color)
                .HasMaxLength(8);

            entityBuilder
                .HasOne(o => o.Owner)
                .WithMany(o => o.Spaces)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
