using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Unions.Commands.UpdateFractions;
using Politica.Test.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Unions.Commands
{
    public class UpdateFractionsCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFractionCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateFractionsCommandHandler(context);

            //Act
            await handler.Handle(
                new UpdateFractionsCommand
                {
                    Id = PoliticaContextFactory.UnionForDelete,
                    Fractions = null
                },
                CancellationToken.None);

            //Assert
            Assert.Empty((await context.Unions.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.UnionForDelete)).Fractions);
        }

        [Fact]
        public async Task UpdateFractionCommandHandler_FailonWrongId()
        {
            //Arrange
            var handler = new UpdateFractionsCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                   new UpdateFractionsCommand
                   {
                       Id = Guid.NewGuid(),
                       Fractions = null
                   },
                CancellationToken.None));
        }

        [Fact]
        public async Task UpdateFractionCommandHandler_FailonPlayerId()
        {
            //Arrange
            var handler = new UpdateFractionsCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                   new UpdateFractionsCommand
                   {
                       Id = Guid.NewGuid(),
                       Fractions = new List<Guid>() { Guid.NewGuid() }
                   },
                CancellationToken.None));
        }
    }
}
