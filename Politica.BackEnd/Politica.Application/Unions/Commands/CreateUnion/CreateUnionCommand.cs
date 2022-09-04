using System;
using System.Collections.Generic;
using MediatR;

namespace Politica.Application.Unions.Commands.CreateUnion
{
    public class CreateUnionCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Guid> Fractions { get; set; }
    }
}
