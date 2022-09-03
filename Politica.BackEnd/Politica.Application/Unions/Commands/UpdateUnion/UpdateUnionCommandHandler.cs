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
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Union), request.Id);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Coordinates = request.Coordinates;
            entity.OwnerId = request.OwnerId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
