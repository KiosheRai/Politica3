using System;
using MediatR;

namespace Politica.Application.Fractions.Queries.GetFractionDetails
{
    public class GetFractionDetailsQuery : IRequest<FractionDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
