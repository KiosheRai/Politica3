﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Politica.Application.Unions.Queries.GetUnionList
{
    public class GetUnionListQueryHandler : 
        IRequestHandler<GetUnionListQuery ,UnionListVm>
    {
        private readonly IPoliticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUnionListQueryHandler(IPoliticaDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UnionListVm> Handle(GetUnionListQuery request,
            CancellationToken cancellationToken)
        {
            var Query = await _dbContext.Unions
                .ProjectTo<UnionLookUpDto>(_mapper.ConfigurationProvider)
                .Where(x => !x.IsDeleted)
                .ToListAsync(cancellationToken);

            return new UnionListVm { Unions = Query };
        }
    }
}
