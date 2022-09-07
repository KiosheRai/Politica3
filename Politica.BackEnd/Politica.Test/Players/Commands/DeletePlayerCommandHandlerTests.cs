using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Players.Commands.DeletePlayer;
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
    public class DeletePlayerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePlayerCommandHandler_Success()
        {
            //Arrange
            var handler = new DeletePlayerCommandHandler(context);

            //Act
            await handler.Handle(
                new DeletePlayerCommand
                {
                    UserId = PoliticaContextFactory.PlayerForDelete
                },
                CancellationToken.None);

            //Assert
            Assert.Null(
                await context.Players.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.PlayerForDelete
                && x.IsDeleted == false));
        }

        [Fact]
        public async Task DeletePlayerCommandHandler_FailWrongId()
        {
            //Arrange
            var handler = new DeletePlayerCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeletePlayerCommand
                    {
                        UserId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
