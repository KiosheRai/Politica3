using Politica.Domain;
using System;
using System.Collections.Generic;
using MediatR;

namespace Politica.Application.Fractions.Commands.UpdatePlayers
{
    public class UpdatePlayersCommand : IRequest
    {
        public Guid Id { get; set; }
        public virtual IEnumerable<Guid> Players { get; set;}
    }
}
