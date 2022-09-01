using System;
using MediatR;

namespace Politica.Application.Fractions.Commands.DeleteFraction
{
    public class DeleteFractionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
