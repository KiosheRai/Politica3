using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Interfaces;
using Politica.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Politica.Application.Players.Queries.GetPlayerDetails
{
    public class GetPlayerDetailsQueryHandler : 
        IRequestHandler<GetPlayerDetailsQuery, PlayerDetailsVm>
    {
        private readonly IPoliticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPlayerDetailsQueryHandler(IPoliticaDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PlayerDetailsVm> Handle(GetPlayerDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Players
                .FirstOrDefaultAsync(player =>
                player.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Player), request.Id);
            }
            return _mapper.Map<PlayerDetailsVm>(entity);
        }

    }
}
