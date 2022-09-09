using Politica.Application.Common.Exceptions;
using Politica.Domain;
using Politica.Application.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace Politica.Application.Fractions.Commands.DeleteFraction
{
    public class DeleteFractionCommandHandler :
        IRequestHandler<DeleteFractionCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public DeleteFractionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFractionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Fractions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Fraction), request.Id);

            entity.IsDeleted = true;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public Task Handle(DeleteFractionCommand deleteFractionCommand, object none)
        {
            throw new NotImplementedException();
        }
    }
}
