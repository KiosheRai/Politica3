using System;
using FluentValidation;

namespace Politica.Application.Fractions.Queries.GetFractionDetails
{
    public class GetFractionDetailsQueryValidator : 
        AbstractValidator<GetFractionDetailsQuery>
    {
        public GetFractionDetailsQueryValidator()
        {
            RuleFor(GetFraction =>
                GetFraction.Id).NotEqual(Guid.Empty);
        }
    }
}
