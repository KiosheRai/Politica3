using System;
using FluentValidation;

namespace Politica.Application.Unions.Commands.UpdateUnion
{
    public class UpdateUnionCommandValidator :
        AbstractValidator<UpdateUnionCommand>
    {
        public UpdateUnionCommandValidator()
        {
            RuleFor(updateUnion =>
                updateUnion.Id).NotEqual(Guid.Empty);
            RuleFor(updateUnion =>
                updateUnion.Title).MinimumLength(50).NotEmpty();
            RuleFor(updateUnion =>
                updateUnion.Description).NotEmpty();
            RuleFor(updateUnion =>
                updateUnion.Coordinates).NotEmpty();
            RuleFor(updateUnion =>
                updateUnion.OwnerId).NotEqual(Guid.Empty);
        }
    }
}
