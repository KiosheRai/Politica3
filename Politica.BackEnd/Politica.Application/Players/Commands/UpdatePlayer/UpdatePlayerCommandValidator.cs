using FluentValidation;
using System;

namespace Politica.Application.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommandValidator : AbstractValidator<UpdatePlayerCommand>
    {
        public UpdatePlayerCommandValidator()
        {
            RuleFor(UpdatePlayerCommand =>
                   UpdatePlayerCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdatePlayerCommand =>
                    UpdatePlayerCommand.Name).Empty();
        }
    }
}
