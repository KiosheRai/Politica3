using System;
using FluentValidation;

namespace Politica.Application.Unions.Commands.DeleteUnion
{
    public class DeleteUnionCommandValidator :
        AbstractValidator<DeleteUnionCommand>
    {
        public DeleteUnionCommandValidator()
        {
            RuleFor(deleteUnion =>
                deleteUnion.Id).NotEqual(Guid.Empty);
        }
    }
}
