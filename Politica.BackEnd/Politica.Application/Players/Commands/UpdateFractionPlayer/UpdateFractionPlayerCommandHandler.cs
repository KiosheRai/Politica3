using MediatR;
using Politica.Application.Interfaces;
using Politica.Application.Common.Exceptions;
using Politica.Domain;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Politica.Application.Players.Commands.UpdateFractionPlayer
{
    public class UpdateFractionPlayerCommandHandler : 
        IRequestHandler<UpdateFractionPlayerCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdateFractionPlayerCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFractionPlayerCommand request,
            CancellationToken cancellationToken)
        {
            var entityPlayer = await _dbContext.Players
                .FirstOrDefaultAsync(player => player.Id == request.Id);

            var entityFraction = await _dbContext.Fractions
                .FirstOrDefaultAsync(fraction => fraction.Id == request.Association);

            if(entityPlayer == null)
                throw new NotFoundException(nameof(Player), request.Id);

            entityPlayer.Association = entityFraction ?? throw new NotFoundException(nameof(Fraction), request.Association);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
