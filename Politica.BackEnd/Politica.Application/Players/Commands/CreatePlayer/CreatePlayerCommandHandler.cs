using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Interfaces;
using Politica.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Politica.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommandHandler
         : IRequestHandler<CreatePlayerCommand, Guid>
    {

        private readonly IPoliticaDbContext _dbContext;

        public CreatePlayerCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePlayerCommand request,
            CancellationToken cancellationToken)
        {
            var inviteid = await _dbContext.Players
                    .FirstOrDefaultAsync(x => x.Id == request.InvitedId);

            if (request.InvitedId != null && inviteid == null)
                throw new NotFoundException(nameof(Player), request.InvitedId);

            var exists = await _dbContext.Players
                .FirstOrDefaultAsync(x => x.HabitId == request.HabitId);

            if (exists != null)
                throw new AlreadyExistsException(nameof(Player), request.HabitId);

            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Habit = request.Habit,
                HabitId = request.HabitId,
                InvitedId = request.InvitedId,
                NickChangeDate = null,
                Association = null,
                IsDeleted = false
                
            };

            await _dbContext.Players.AddAsync(player, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return player.Id;
        }
    }
}
