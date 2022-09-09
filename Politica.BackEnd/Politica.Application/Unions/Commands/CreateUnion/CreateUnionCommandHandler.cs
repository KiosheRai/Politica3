using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Politica.Application.Interfaces;
using Politica.Domain;
using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;

namespace Politica.Application.Unions.Commands.CreateUnion
{
    public class CreateUnionCommandHandler :
        IRequestHandler<CreateUnionCommand, Guid>
    {
        private readonly IPoliticaDbContext _dbContext;

        public CreateUnionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUnionCommand request,
            CancellationToken cancellationToken)
        {
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

            var owner = await _dbContext.Players.
               FirstOrDefaultAsync(x => x.Id == request.OwnerId)
                   ?? throw new NotFoundException(nameof(Player), request.OwnerId);

            var union = new Union
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Coordinates = request.Coordinates,
                Fractions = fractions,
                OwnerId = owner.Id,
                IsDeleted = false
            };

            await _dbContext.Unions.AddAsync(union, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return union.Id;
        }
    }
}
