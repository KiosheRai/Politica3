using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Players.Commands.UpdateFractionPlayer;
using Politica.Test.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Players.Commands
{
    public class UpdateFractionPlayerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePlayerCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateFractionPlayerCommandHandler(context);

            //Act
            await handler.Handle(
                new UpdateFractionPlayerCommand
                {
                   Id = PoliticaContextFactory.PlayerForUpdate,
                   Association = PoliticaContextFactory.FractionForAccessPlayer
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Players.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.PlayerForUpdate
                && x.Association.Id == PoliticaContextFactory.FractionForAccessPlayer));
        }

        [Fact]
        public async Task UpdatePlayerCommandHandler_WrongPlayerId()
        {
            //Arrange
            var handler = new UpdateFractionPlayerCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                         new UpdateFractionPlayerCommand
                         {
                             Id = Guid.NewGuid(),
                             Association = PoliticaContextFactory.FractionForAccessPlayer
                         },
                         CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePlayerCommandHandler_WrongFractionId()
        {
            //Arrange
            var handler = new UpdateFractionPlayerCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                         new UpdateFractionPlayerCommand
                         {
                             Id = PoliticaContextFactory.PlayerForUpdate,
                             Association = Guid.NewGuid()
                         },
                         CancellationToken.None));
        }
    }
}
