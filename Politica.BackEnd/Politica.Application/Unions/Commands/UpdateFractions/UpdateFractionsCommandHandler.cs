using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Politica.Application.Interfaces;
using Politica.Application.Common.Exceptions;
using Politica.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Politica.Application.Unions.Commands.UpdateFractions
{
    public class UpdateFractionsCommandHandler :
        IRequestHandler<UpdateFractionsCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdateFractionsCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFractionsCommand request,
            CancellationToken cancellationToken)
        {
            var union = await _dbContext.Unions
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Union), request.Id); ;

            var fractions = await _dbContext.Fractions
                .ToListAsync(cancellationToken);

            IEnumerable<Fraction> entities = new List<Fraction>();

            if (request.Fractions != null)
            {
                foreach (var fractionId in request.Fractions)
                {
                    entities.Append(fractions.FirstOrDefault(x => x.Id == fractionId)
                        ?? throw new NotFoundException(nameof(Fraction), fractionId));
                }
            }

            union.Fractions = entities;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
