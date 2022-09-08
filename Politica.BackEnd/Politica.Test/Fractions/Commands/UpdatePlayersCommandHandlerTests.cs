using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Fractions.Commands.UpdatePlayers;
using Politica.Test.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Fractions.Commands
{
    public class UpdatePlayersCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFractionCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdatePlayersCommandHandler(context);

            //Act
            await handler.Handle(
                new UpdatePlayersCommand
                {
                    Id = PoliticaContextFactory.FractionForUpdate,
                    Players = null
                },
                CancellationToken.None);

            //Assert
            Assert.Null((await context.Fractions.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.FractionForUpdate)).Players);
        }

        [Fact]
        public async Task UpdateFractionCommandHandler_FailonWrongId()
        {
            //Arrange
            var handler = new UpdatePlayersCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => 
                await handler.Handle(
                   new UpdatePlayersCommand
                   {
                       Id = Guid.NewGuid(),
                       Players = null
                   },
                CancellationToken.None));
        }

        [Fact]
        public async Task UpdateFractionCommandHandler_FailonPlayerId()
        {
            //Arrange
            var handler = new UpdatePlayersCommandHandler(context);



            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                   new UpdatePlayersCommand
                   {
                       Id = Guid.NewGuid(),
                       Players = new List<Guid>() { Guid.NewGuid() }
                   },
                CancellationToken.None));
        }
    }
}
