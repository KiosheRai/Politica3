using FluentValidation;
using System;

namespace Politica.Application.Unions.Queries.GetUnionDetails
{
    public class GetUnionDetailsQueryValidator :
        AbstractValidator<GetUnionDetailsQuery>
    {
        public GetUnionDetailsQueryValidator()
        {
            RuleFor(getUnionDetails =>
                getUnionDetails.Id).NotEqual(Guid.Empty);
        }
    }
}
