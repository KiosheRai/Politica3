using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Politica.Application.Common.Exceptions;
using Politica.Domain;

namespace Politica.Application.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommandHandler
         : IRequestHandler<UpdatePlayerCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdatePlayerCommandHandler(IPoliticaDbContext context) => 
            _dbContext = context;

        public async Task<Unit> Handle(UpdatePlayerCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Players.FirstOrDefaultAsync(player => player.Id == request.Id, cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Player), request.Id);

            TimeSpan? timespan = DateTime.Now - entity.NickChangeDate;
            if (timespan is TimeSpan time) {
                if (time < TimeSpan.FromHours(24))
                    throw new ChangeNickTimeException(nameof(Player), request.Id, time);
            }

            entity.Name = request.Name;
            entity.NickChangeDate = DateTime.Now;
            

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
