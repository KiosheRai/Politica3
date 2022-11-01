using System;
using FluentValidation;

namespace Politica.Application.Fractions.Commands.UpdateFraction
{
    public class UpdateFractionCommandValidator :
        AbstractValidator<UpdateFractionCommand>
    {
        public UpdateFractionCommandValidator()
        {
            RuleFor(updateFractionCommand  =>
                updateFractionCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateFractionCommand  =>
               updateFractionCommand.Title).MaximumLength(50).NotEmpty();
            RuleFor(updateFractionCommand  =>
                updateFractionCommand.Description).NotEmpty();
            RuleFor(updateFractionCommand  =>
                updateFractionCommand.OwnerId).NotEqual(Guid.Empty);
        }

    }
}
