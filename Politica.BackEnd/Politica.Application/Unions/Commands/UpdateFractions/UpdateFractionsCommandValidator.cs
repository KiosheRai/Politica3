using System;
using FluentValidation;

namespace Politica.Application.Unions.Commands.UpdateFractions
{
    public class UpdateFractionsCommandValidator : 
        AbstractValidator<UpdateFractionsCommand>
    {
        public UpdateFractionsCommandValidator()
        {
            RuleFor(updateFractions =>
                updateFractions.Id).NotEqual(Guid.Empty);
        }
    }
}
