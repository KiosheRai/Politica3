using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Fractions.Commands.UpdateFraction;
using Politica.Test.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Fractions.Commands
{
    public class UpdateFractionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFractionCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateFractionCommandHandler(context);
            var Title = "New Title";
            var Description = "New description";
            var Coordinates = "100 100";

            //Act
            await handler.Handle(
                new UpdateFractionCommand
                {
                    Id = PoliticaContextFactory.FractionForUpdate,
                    Title = Title,
                    Description = Description,
                    Coordinates = Coordinates,
                    OwnerId = PoliticaContextFactory.PlayerFractionOwner
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Fractions.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.FractionForUpdate
                && x.Title == Title
                && x.Description == Description
                && x.Coordinates == Coordinates
                && x.OwnerId == PoliticaContextFactory.PlayerFractionOwner));
        }

        [Fact]
        public async Task UpdateFractionCommandHandler_FailFractionId()
        {
            //Arrange
            var handler = new UpdateFractionCommandHandler(context);
            var Title = "New Title";
            var Description = "New description";
            var Coordinates = "100 100";

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFractionCommand
                    {
                        Id = Guid.NewGuid(),
                        Title = Title,
                        Description = Description,
                        Coordinates = Coordinates,
                        OwnerId = PoliticaContextFactory.PlayerFractionOwner
                    },
                CancellationToken.None));
        }

        [Fact]
        public async Task UpdateFractionCommandHandler_FailOwnerIdChange()
        {
            //Arrange
            var handler = new UpdateFractionCommandHandler(context);
            var Title = "New Title";
            var Description = "New description";
            var Coordinates = "100 100";

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFractionCommand
                    {
                        Id = PoliticaContextFactory.FractionForUpdate,
                        Title = Title,
                        Description = Description,
                        Coordinates = Coordinates,
                        OwnerId = Guid.NewGuid()
                    },
                CancellationToken.None));
        }
    }
}
