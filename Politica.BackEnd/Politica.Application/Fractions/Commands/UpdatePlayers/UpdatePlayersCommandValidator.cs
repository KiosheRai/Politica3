using System;
using FluentValidation;

namespace Politica.Application.Fractions.Commands.UpdatePlayers
{
    public class UpdatePlayersCommandValidator 
        : AbstractValidator<UpdatePlayersCommand>
    {
        public UpdatePlayersCommandValidator()
        {
            RuleFor(UpdatePlayers =>
                UpdatePlayers.Id).NotEqual(Guid.Empty);
        }
    }
}
