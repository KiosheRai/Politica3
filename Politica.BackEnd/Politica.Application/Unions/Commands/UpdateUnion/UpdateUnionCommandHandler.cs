using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Politica.Application.Common.Exceptions;
using Politica.Application.Interfaces;
using Politica.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Politica.Application.Unions.Commands.UpdateUnion
{
    public class UpdateUnionCommandHandler : 
        IRequestHandler<UpdateUnionCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdateUnionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUnionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Unions
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Union), request.Id);

            var owner = await _dbContext.Players.
              FirstOrDefaultAsync(x => x.Id == request.OwnerId)
                  ?? throw new NotFoundException(nameof(Player), request.OwnerId);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Coordinates = request.Coordinates;
            entity.OwnerId = owner.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
