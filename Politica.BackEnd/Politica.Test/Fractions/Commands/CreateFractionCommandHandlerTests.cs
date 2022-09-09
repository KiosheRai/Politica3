using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Fractions.Commands.CreateFraction;
using Politica.Test.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Fractions.Commands
{
    public class CreateFractionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFractionCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateFractionCommandHandler(context);
            var Title = "Орден креста";
            var Description = "Описание";
            var Coordinates = "2 2";

            //Act
            var Id = await handler.Handle(
                new CreateFractionCommand
                {
                    Title = Title,
                    Description = Description,
                    Coordinates = Coordinates,
                    OwnerId = PoliticaContextFactory.PlayerOne,
                    Players = null,
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Fractions.SingleOrDefaultAsync(x =>
                x.Id == Id
                && x.Title == Title
                && x.Description == Description
                && x.Coordinates == Coordinates
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateFractionCommandHandler_SuccessWithPlayers()
        {
            //Arrange
            var handler = new CreateFractionCommandHandler(context);
            var Title = "Орден креста";
            var Description = "Описание";
            var Coordinates = "2 2";

            //Act
            var Id = await handler.Handle(
                new CreateFractionCommand
                {
                    Title = Title,
                    Description = Description,
                    Coordinates = Coordinates,
                    OwnerId = PoliticaContextFactory.PlayerOne,
                    Players = new List<Guid> { PoliticaContextFactory.PlayerForDetails },
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Fractions.SingleOrDefaultAsync(x =>
                x.Id == Id
                && x.Title == Title
                && x.Description == Description
                && x.Coordinates == Coordinates
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateFractionCommandHandler_FailOnWrongPlayerId()
        {
            //Arrange
            var handler = new CreateFractionCommandHandler(context);
            var Title = "Орден креста";
            var Description = "Описание";
            var Coordinates = "2 2";
            IEnumerable<Guid> players = new List<Guid>() {
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            //Act
          
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new CreateFractionCommand
                    {
                        Title = Title,
                        Description = Description,
                        Coordinates = Coordinates,
                        OwnerId = PoliticaContextFactory.PlayerOne,
                        Players = players,
                    },
                CancellationToken.None);
            });
        }

        [Fact]
        public async Task CreateFractionCommandHandler_FailOnWrongOwnerId()
        {
            //Arrange
            var handler = new CreateFractionCommandHandler(context);
            var Title = "Орден креста";
            var Description = "Описание";
            var Coordinates = "2 2";

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new CreateFractionCommand
                    {
                        Title = Title,
                        Description = Description,
                        Coordinates = Coordinates,
                        OwnerId = Guid.NewGuid(),
                        Players = null,
                    },
                CancellationToken.None);
            });
        }
    }
}
