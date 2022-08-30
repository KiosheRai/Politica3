using MediatR;
using Politica.Application.Interfaces;
using Politica.Domain;
using System;
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
