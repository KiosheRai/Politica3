using System;
using MediatR;

namespace Politica.Application.Unions.Commands.UpdateUnion
{
    public class UpdateUnionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public virtual Guid OwnerId { get; set; }
    }
}
