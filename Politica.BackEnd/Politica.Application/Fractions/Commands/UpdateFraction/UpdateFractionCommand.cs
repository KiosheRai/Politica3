using System;
using System.Collections.Generic;
using MediatR;
using Politica.Domain;

namespace Politica.Application.Fractions.Commands.UpdateFraction
{
    public class UpdateFractionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public Guid OwnerId { get; set; }
    }
}
