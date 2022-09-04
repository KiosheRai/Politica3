using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using Politica.Application.Interfaces;
using Politica.Application.Common.Exceptions;
using System.Threading.Tasks;
using System.Threading;
using Politica.Domain;
using Microsoft.EntityFrameworkCore;

namespace Politica.Application.Fractions.Commands.UpdatePlayers
{
    public class UpdatePlayersCommandHandler : IRequestHandler<UpdatePlayersCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdatePlayersCommandHandler(IPoliticaDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePlayersCommand request,
            CancellationToken cancellationToken)
        {
            var fraction = await _dbContext.Fractions
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            var players = await _dbContext.Players
                .ToListAsync(cancellationToken);

            if (fraction == null)
                throw new NotFoundException(nameof(Fraction), request.Id);

            if(request.Players == null)
            {
                fraction.Players = null;
                return Unit.Value;
            }

            IEnumerable<Player> entities = new List<Player>();

            foreach(var playerId in request.Players)
            {
               entities.Append(players.FirstOrDefault(x => x.Id == playerId) ?? throw new NotFoundException(nameof(Player), playerId)) ;
            }

            fraction.Players = entities;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
