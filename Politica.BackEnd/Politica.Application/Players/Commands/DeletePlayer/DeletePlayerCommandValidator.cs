using FluentValidation;
using System;

namespace Politica.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommandValidator : AbstractValidator<DeletePlayerCommand>
    {
        public DeletePlayerCommandValidator()
        {
            RuleFor(DeletePlayerCommand =>
                    DeletePlayerCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
