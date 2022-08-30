using FluentValidation;

namespace Politica.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            RuleFor(CreateEventCommand =>
                CreateEventCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(CreateEventCommand =>
                CreateEventCommand.Habit).NotEmpty();
            RuleFor(CreateEventCommand =>
                CreateEventCommand.HabitId).NotEmpty();
        }
    }
}
