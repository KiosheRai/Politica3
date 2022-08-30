using FluentValidation;
using System;

namespace Politica.Application.Players.Queries.GetPlayerDetails
{
    public class GetPlayerDetailsQueryValidator : AbstractValidator<GetPlayerDetailsQuery>
    {
        public GetPlayerDetailsQueryValidator()
        {
            RuleFor(player => player.Id).NotEqual(Guid.Empty);
        }
    }
}
