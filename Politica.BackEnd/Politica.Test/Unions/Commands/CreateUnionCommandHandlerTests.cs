using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Unions.Commands.CreateUnion;
using Politica.Domain;
using Politica.Test.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Unions.Commands
{
    public class CreateUnionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateUnionCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateUnionCommandHandler(context);
            var title = "Союз";
            var description = "Описание";
            var coordinateX = 3;
            var coordinateZ = 3;

            //Act
            var Id = await handler.Handle(
                new CreateUnionCommand
                {
                    Title = title,
                    Description = description,
                    CoordinateX = coordinateX,
                    CoordinateZ = coordinateZ,
                    OwnerId = PoliticaContextFactory.PlayerOne,
                    Fractions = null,
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Unions.SingleOrDefaultAsync(x =>
                x.Id == Id
                && x.Title == title
                && x.Description == description
                && x.CoordinateX == coordinateX
                && x.CoordinateZ == coordinateZ
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateUnionCommandHandler_SuccessWithUnions()
        {
            //Arrange
            var handler = new CreateUnionCommandHandler(context);
            var title = "Союз";
            var description = "Описание";
            var coordinateX = 3;
            var coordinateZ = 3;

            //Act
            var Id = await handler.Handle(
                new CreateUnionCommand
                {
                    Title = title,
                    Description = description,
                    CoordinateX = coordinateX,
                    CoordinateZ = coordinateZ,
                    OwnerId = PoliticaContextFactory.PlayerOne,
                    Fractions = new List<Guid> { PoliticaContextFactory.FractionForDetails },
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Unions.SingleOrDefaultAsync(x =>
                x.Id == Id
                && x.Title == title
                && x.Description == description
                && x.CoordinateX == coordinateX
                && x.CoordinateZ == coordinateZ
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateUnionCommandHandler_FailOnWrongUnionsId()
        {
            //Arrange
            var handler = new CreateUnionCommandHandler(context);
            var title = "Союз";
            var description = "Описание";
            var coordinateX = 3;
            var coordinateZ = 3;

            IEnumerable<Guid> Unions = new List<Guid>() {
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new CreateUnionCommand
                    {
                        Title = title,
                        Description = description,
                        CoordinateX = coordinateX,
                        CoordinateZ = coordinateZ,
                        OwnerId = PoliticaContextFactory.PlayerOne,
                        Fractions = Unions,
                    },
                CancellationToken.None);
            });
        }

        [Fact]
        public async Task CreateUnionCommandHandler_FailOnWrongOwnerId()
        {
            //Arrange
            var handler = new CreateUnionCommandHandler(context);
            var Title = "Союз";
            var Description = "Описание";
            var coordinateX = 3;
            var coordinateZ = 3;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new CreateUnionCommand
                    {
                        Title = Title,
                        Description = Description,
                        CoordinateX = coordinateX,
                        CoordinateZ = coordinateZ,
                        OwnerId = Guid.NewGuid(),
                        Fractions = null,
                    },
                CancellationToken.None);
            });
        }
    }
}
