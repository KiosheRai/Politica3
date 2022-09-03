using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Interfaces;
using Politica.Domain;
using System.Threading;
using System.Threading.Tasks;


namespace Politica.Application.Unions.Queries.GetUnionDetails
{
    public class GetUnionDetailsQueryHandler :
         IRequestHandler<GetUnionDetailsQuery, UnionDetailsVm>
    {
        private readonly IPoliticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUnionDetailsQueryHandler(IPoliticaDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UnionDetailsVm> Handle(GetUnionDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Unions
              .FirstOrDefaultAsync(union =>
              union.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Union), request.Id);
            }

            return _mapper.Map<UnionDetailsVm>(entity);
        }
    }
}
