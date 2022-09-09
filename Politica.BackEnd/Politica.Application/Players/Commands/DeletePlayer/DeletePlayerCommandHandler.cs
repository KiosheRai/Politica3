using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Interfaces;
using Politica.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Politica.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommandHandler
        : IRequestHandler<DeletePlayerCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public DeletePlayerCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePlayerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Players
                .FirstOrDefaultAsync(player => player.Id == request.UserId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Player), request.UserId);

            entity.IsDeleted = true;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
