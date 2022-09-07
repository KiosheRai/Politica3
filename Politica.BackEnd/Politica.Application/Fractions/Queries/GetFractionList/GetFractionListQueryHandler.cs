using System.Threading.Tasks;
using MediatR;
using Politica.Application.Interfaces;
using AutoMapper;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Politica.Application.Fractions.Queries.GetFractionList
{
    public class GetFractionListQueryHandler :
        IRequestHandler<GetFractionListQuery, FractionListVm>
    {
        private readonly IPoliticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFractionListQueryHandler(IPoliticaDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FractionListVm> Handle(GetFractionListQuery request,
            CancellationToken cancellationToken)
        {
            var Query = await _dbContext.Players
                .ProjectTo<FractionLookUpDto>(_mapper.ConfigurationProvider)
                .Where(x => x.IsDeleted == false)
                .ToListAsync(cancellationToken);

            return new FractionListVm { Fractions = Query };
        }
    }
}
