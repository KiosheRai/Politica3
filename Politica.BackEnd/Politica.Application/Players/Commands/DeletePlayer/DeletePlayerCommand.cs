using MediatR;
using System;

namespace Politica.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
