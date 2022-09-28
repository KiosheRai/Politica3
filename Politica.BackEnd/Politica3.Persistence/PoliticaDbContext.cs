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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FractionConfiguration());
            modelBuilder.ApplyConfiguration(new UnionConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
