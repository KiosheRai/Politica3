using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Players.Commands.UpdatePlayer;
using Politica.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Players.Commands
{
    public class UpdatePlayerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePlayerCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdatePlayerCommandHandler(context);
            var Name = "New Name";

            //Act
            await handler.Handle(
                new UpdatePlayerCommand
                {
                   Id = PoliticaContextFactory.PlayerForUpdate,
                   Name = Name,
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Players.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.PlayerForUpdate
                && x.Name == Name));
        }

        [Fact]
        public async Task UpdatePlayerCommandHandler_FailTimeChange()
        {
            //Arrange
            var handler = new UpdatePlayerCommandHandler(context);
            var Name = "New Name";

            //Act
            await handler.Handle(
                new UpdatePlayerCommand
                {
                    Id = PoliticaContextFactory.PlayerForUpdate,
                    Name = Name,
                },
                CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<ChangeNickTimeException>(async () =>
                await handler.Handle(
                    new UpdatePlayerCommand
                    {
                        Id = PoliticaContextFactory.PlayerForUpdate,
                        Name = Name
                    },
                    CancellationToken.None));
        }
    }
}
