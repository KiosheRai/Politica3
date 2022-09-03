using MediatR;
using System;

namespace Politica.Application.Unions.Queries.GetUnionDetails
{
    public class GetUnionDetailsQuery : IRequest<UnionDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
