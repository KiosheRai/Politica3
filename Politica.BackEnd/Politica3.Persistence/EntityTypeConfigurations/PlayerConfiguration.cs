using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politica.Domain;

namespace Politica.Persistence.EntityTypeConfigurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(player => player.Id);
            builder.HasIndex(player => player.Id).IsUnique();
            builder.Property(player => player.Name).HasMaxLength(50).IsRequired();
            builder.Property(player => player.Habit).IsRequired();
            builder.HasIndex(player => player.HabitId).IsUnique();
            builder.Property(player => player.IsDeleted).HasDefaultValue(false);
        }
    }
}
