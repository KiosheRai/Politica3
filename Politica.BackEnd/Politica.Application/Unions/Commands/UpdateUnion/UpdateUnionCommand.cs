using System;
using MediatR;
using Politica.Domain;

namespace Politica.Application.Unions.Commands.UpdateUnion
{
    public class UpdateUnionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public virtual Guid OwnerId { get; set; }
    }
}
