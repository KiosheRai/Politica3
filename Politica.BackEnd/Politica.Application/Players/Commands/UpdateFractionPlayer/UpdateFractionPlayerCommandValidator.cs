using System;
using FluentValidation;

namespace Politica.Application.Players.Commands.UpdateFractionPlayer
{
    public class UpdateFractionPlayerCommandValidator
        : AbstractValidator<UpdateFractionPlayerCommand>
    {
        public UpdateFractionPlayerCommandValidator()
        {
            RuleFor(updateFraction =>
                updateFraction.Id).NotEqual(Guid.Empty);
        }
    }
}
