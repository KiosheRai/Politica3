﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Politica.Application.Interfaces;
using Politica.Application.Common.Exceptions;
using Politica.Domain;

namespace Politica.Application.Fractions.Commands.UpdateFraction
{
    public class UpdateFractionCommandHandler 
        : IRequestHandler<UpdateFractionCommand>
    {
        private readonly IPoliticaDbContext _dbContext;

        public UpdateFractionCommandHandler(IPoliticaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFractionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Fractions
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Fraction), request.Id);

            var OwnerId = await _dbContext.Players
                .FirstOrDefaultAsync(x=>x.Id == request.OwnerId)
                    ?? throw new NotFoundException(nameof(Player), request.OwnerId);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.CoordinateX = request.CoordinateX;
            entity.CoordinateZ = request.CoordinateZ;
            entity.OwnerId = OwnerId.Id;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
