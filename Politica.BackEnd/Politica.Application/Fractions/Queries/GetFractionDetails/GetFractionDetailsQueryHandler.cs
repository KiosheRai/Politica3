using System.Threading;
using Politica.Application.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Domain;

namespace Politica.Application.Fractions.Queries.GetFractionDetails
{
    public class GetFractionDetailsQueryHandler :
        IRequestHandler<GetFractionDetailsQuery, FractionDetailsVm>
    {
        private readonly IPoliticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFractionDetailsQueryHandler(IPoliticaDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FractionDetailsVm> Handle(GetFractionDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Fractions
              .FirstOrDefaultAsync(fraction =>
              fraction.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Fraction), request.Id);
            }

            return _mapper.Map<FractionDetailsVm>(entity);
        }
    }
}
