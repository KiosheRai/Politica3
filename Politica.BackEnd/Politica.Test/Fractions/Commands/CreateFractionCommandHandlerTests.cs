using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Fractions.Commands.CreateFraction;
using Politica.Domain;
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
            var title = "Орден креста";
            var description = "Описание";
            var coordinateX = 123;
            var coordinateZ = 322;

            //Act
            var Id = await handler.Handle(
                new CreateFractionCommand
                {
                    Title = title,
                    Description = description,
                    CoordinateX = coordinateX,
                    CoordinateZ = coordinateZ,
                    OwnerId = PoliticaContextFactory.PlayerOne,
                    Players = null,
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Fractions.SingleOrDefaultAsync(x =>
                x.Id == Id
                && x.Title == title
                && x.Description == description
                && x.CoordinateX == coordinateX
                && x.CoordinateZ == coordinateZ
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateFractionCommandHandler_SuccessWithPlayers()
        {
            //Arrange
            var handler = new CreateFractionCommandHandler(context);
            var Title = "Орден креста";
            var Description = "Описание";
            var coordinateX = 123;
            var coordinateZ = 322;

            //Act
            var Id = await handler.Handle(
                new CreateFractionCommand
                {
                    Title = Title,
                    Description = Description,
                    CoordinateX = coordinateX,
                    CoordinateZ = coordinateZ,
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
                && x.CoordinateX == coordinateX
                && x.CoordinateZ == coordinateZ
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateFractionCommandHandler_FailOnWrongPlayerId()
        {
            //Arrange
            var handler = new CreateFractionCommandHandler(context);
            var Title = "Орден креста";
            var Description = "Описание";
            var coordinateX = 123;
            var coordinateZ = 322;

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
                        CoordinateX = coordinateX,
                        CoordinateZ = coordinateZ,
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
            var coordinateX = 123;
            var coordinateZ = 322;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new CreateFractionCommand
                    {
                        Title = Title,
                        Description = Description,
                        CoordinateX = coordinateX,
                        CoordinateZ = coordinateZ,
                        OwnerId = Guid.NewGuid(),
                        Players = null,
                    },
                CancellationToken.None);
            });
        }
    }
}
