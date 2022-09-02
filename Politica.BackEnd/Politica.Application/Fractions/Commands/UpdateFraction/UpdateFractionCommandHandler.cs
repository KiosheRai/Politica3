using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Interfaces;
using Politica.Application.Common.Exceptions;
using Politica.Domain;

namespace Politica.Application.Fractions.Commands.UpdateFraction
{
    public class UpdateFractionCommandHandler 
        : IRequestHandler<UpdateFractionCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdateFractionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFractionCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Fractions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Fraction), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Coordinates = request.Coordinates;
            entity.OwnerId = request.OwnerId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        
    }
}
