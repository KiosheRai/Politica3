using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politica.Domain;

namespace Politica.Persistence.EntityTypeConfigurations
{
    public class FractionConfiguration : IEntityTypeConfiguration<Fraction>
    {
        public void Configure(EntityTypeBuilder<Fraction> builder)
        {
            builder.HasKey(fraction => fraction.Id);
            builder.HasIndex(fraction => fraction.Id).IsUnique();
            builder.Property(fraction => fraction.Title).HasMaxLength(50).IsRequired();
            builder.Property(fraction => fraction.Description).IsRequired();
            builder.Property(fraction => fraction.CoordinateX).IsRequired();
            builder.Property(fraction => fraction.CoordinateZ).IsRequired();
            builder.Property(fraction => fraction.IsDeleted).HasDefaultValue(false);
        }
    }
}
