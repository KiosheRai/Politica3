﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politica.Domain;

namespace Politica.Persistence.EntityTypeConfigurations
{
    public class UnionConfiguration : IEntityTypeConfiguration<Union>
    {
        public void Configure(EntityTypeBuilder<Union> builder)
        {
            builder.HasKey(union => union.Id);
            builder.HasIndex(union => union.Id).IsUnique();
            builder.Property(union => union.Title).HasMaxLength(50);
        }
    }
}
