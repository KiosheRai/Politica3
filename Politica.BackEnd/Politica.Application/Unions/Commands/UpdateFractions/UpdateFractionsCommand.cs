using System;
using System.Collections.Generic;
using MediatR;

namespace Politica.Application.Unions.Commands.UpdateFractions
{
    public class UpdateFractionsCommand : IRequest
    {
        public Guid Id { get; set; }
        public virtual IEnumerable<Guid> Fractions { get; set; }
    }
}
