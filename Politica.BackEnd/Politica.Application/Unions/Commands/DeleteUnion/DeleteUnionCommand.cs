using System;
using MediatR;

namespace Politica.Application.Unions.Commands.DeleteUnion
{
    public class DeleteUnionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
