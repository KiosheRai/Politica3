using FluentValidation;
using System;

namespace Politica.Application.Fractions.Commands.CreateFraction
{
    public class CreateFractionCommandValidator : AbstractValidator<CreateFractionCommand>
    {
        public CreateFractionCommandValidator()
        {
            RuleFor(createFractionCommand =>
                createFractionCommand.Title).MaximumLength(50).NotEmpty();
            RuleFor(createFractionCommand =>
                createFractionCommand.Description).NotEmpty();
            RuleFor(createFractionCommand =>
                createFractionCommand.Coordinates).NotEmpty();
            RuleFor(createFractionCommand =>
                createFractionCommand.OwnerId).NotEqual(Guid.Empty);
        }
    }
}
