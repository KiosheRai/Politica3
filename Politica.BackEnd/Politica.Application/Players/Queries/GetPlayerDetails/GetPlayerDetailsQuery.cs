using MediatR;
using System;

namespace Politica.Application.Players.Queries.GetPlayerDetails
{
    public class GetPlayerDetailsQuery : IRequest<PlayerDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
