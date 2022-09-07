using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Politica.Application.Players.Queries.GetPlayerList
{
    public class GetPlayerListQueryHandler :
       IRequestHandler<GetPlayerListQuery, PlayerListVm>
    {
        private readonly IPoliticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPlayerListQueryHandler(IPoliticaDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PlayerListVm> Handle(GetPlayerListQuery request,
            CancellationToken cancellationToken)
        {
            var Query = await _dbContext.Players
                .ProjectTo<PlayerLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PlayerListVm { Players = Query };
        }
    }

}