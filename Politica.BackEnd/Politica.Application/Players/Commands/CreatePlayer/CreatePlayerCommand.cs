using MediatR;
using System;

namespace Politica.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Habit { get; set; }
        public int HabitId { get; set; }
        public Guid? InvitedId { get; set; }
    }
}
