using MediatR;
using System;

namespace Politica.Application.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
