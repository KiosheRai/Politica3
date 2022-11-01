using System;
using System.Collections.Generic;
using MediatR;
using Politica.Domain;

namespace Politica.Application.Unions.Commands.CreateUnion
{
    public class CreateUnionCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Guid> Fractions { get; set; }
    }
}
