using Microsoft.EntityFrameworkCore;
using Politica.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Politica.Application.Interfaces
{
    public interface IPoliticaDbContext
    {
        DbSet<Fraction> Fractions { get; set; }
        DbSet<Union> Unions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
