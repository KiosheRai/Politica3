using System;
using MediatR;

namespace Politica.Application.Players.Commands.UpdateFractionPlayer
{
    public class UpdateFractionPlayerCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid? Association { get; set; }
    }
}
