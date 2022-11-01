using System;
using FluentValidation;

namespace Politica.Application.Unions.Commands.CreateUnion
{
    public class CreateUnionCommandValidator : 
        AbstractValidator<CreateUnionCommand>
    {
        public CreateUnionCommandValidator()
        {
            RuleFor(createUnion =>
                createUnion.Title).MaximumLength(50).NotEmpty();
            RuleFor(createUnion =>
                createUnion.Description).NotEmpty();
            RuleFor(createUnion =>
                createUnion.OwnerId).NotEqual(Guid.Empty);
        }
    }
}
