using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politica.Persistence.EntityTypeConfigurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(player => player.Id);
            builder.HasIndex(player => player.Id).IsUnique();
            builder.Property(player => player.Name).HasMaxLength(50);
            //builder.Property(player => player.AssociationId).IsOptional();
        }
    }
}
