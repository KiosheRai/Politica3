using System.Threading.Tasks;
using Politica.Application.Interfaces;
using Politica.Application.Common.Exceptions;
using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Domain;

namespace Politica.Application.Unions.Commands.DeleteUnion
{
    public class DeleteUnionCommandHandler : 
        IRequestHandler<DeleteUnionCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public DeleteUnionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUnionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Unions.
                FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Union), request.Id);
                
            entity.IsDeleted = true;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
