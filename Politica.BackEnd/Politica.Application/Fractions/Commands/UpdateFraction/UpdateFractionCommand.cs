using MediatR;
using Politica.Domain;
using System;

namespace Politica.Application.Fractions.Commands.UpdateFraction
{
    public class UpdateFractionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public Guid OwnerId { get; set; }
    }
}
