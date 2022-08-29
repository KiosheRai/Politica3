using Microsoft.EntityFrameworkCore;
using Politica.Application.Interfaces;
using Politica.Domain;
using Politica.Persistence.EntityTypeConfigurations;

namespace Politica.Persistence
{
    public class PoliticaDbContext : DbContext, IPoliticaDbContext
    {
        public DbSet<Fraction> Fractions { get; set; }
        public DbSet<Union> Unions { get; set; }
        public DbSet<Player> Players { get; set; }

        public PoliticaDbContext(DbContextOptions<PoliticaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FractionConfiguration());
            builder.ApplyConfiguration(new UnionConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
