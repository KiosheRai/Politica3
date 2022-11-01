using System;
using Politica.Domain;
using Politica.Application.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Politica.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Politica.Application.Fractions.Commands.CreateFraction
{
    public class CreateFractionCommandHandler : 
        IRequestHandler<CreateFractionCommand, Guid>
    {

        private readonly IPoliticaDbContext _dbContext;

        public CreateFractionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFractionCommand request,
            CancellationToken cancellationToken)
        {
            var players = await _dbContext.Players
                .ToListAsync(cancellationToken);

            IEnumerable<Player> entities = new List<Player>();

            if (request.Players != null)
            {
                foreach (var playerId in request.Players)
                {
                    _ = entities.Append(players.FirstOrDefault(x => x.Id == playerId)
                        ?? throw new NotFoundException(nameof(Player), playerId));
                }
            }

            var owner = await _dbContext.Players.
                FirstOrDefaultAsync(x => x.Id == request.OwnerId) 
                    ?? throw new NotFoundException(nameof(Player), request.OwnerId);

            var entity = new Fraction
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                CoordinateX = request.CoordinateX,
                CoordinateZ = request.CoordinateZ,
                OwnerId = owner.Id,
                Players = entities,
                Association = null,
                IsDeleted = false
            };

            await _dbContext.Fractions.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
