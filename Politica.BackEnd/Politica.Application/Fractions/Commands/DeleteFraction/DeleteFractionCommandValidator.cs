using FluentValidation;
using System;

namespace Politica.Application.Fractions.Commands.DeleteFraction
{
    public class DeleteFractionCommandValidator :
        AbstractValidator<DeleteFractionCommand>
    {
        public DeleteFractionCommandValidator()
        {
            RuleFor(deleteFractionCommand =>
                deleteFractionCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
