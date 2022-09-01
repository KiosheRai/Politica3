using System;
using Politica.Domain;
using Politica.Application.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

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
            var entity = new Fraction
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Coordinates = request.Coordinates,
                OwnerId = request.OwnerId,
                ListPlayers = request.ListPlayers,
                Association = null,
                IsDeleted = false
            };

            await _dbContext.Fractions.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
