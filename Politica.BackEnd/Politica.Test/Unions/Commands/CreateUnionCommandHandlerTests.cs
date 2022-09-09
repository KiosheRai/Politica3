using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Unions.Commands.CreateUnion;
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
            var coordinates = "3 3";

            //Act
            var Id = await handler.Handle(
                new CreateUnionCommand
                {
                    Title = title,
                    Description = description,
                    Coordinates = coordinates,
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
                && x.Coordinates == coordinates
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateUnionCommandHandler_SuccessWithUnions()
        {
            //Arrange
            var handler = new CreateUnionCommandHandler(context);
            var title = "Союз";
            var description = "Описание";
            var coordinates = "2 2";

            //Act
            var Id = await handler.Handle(
                new CreateUnionCommand
                {
                    Title = title,
                    Description = description,
                    Coordinates = coordinates,
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
                && x.Coordinates == coordinates
                && x.OwnerId == PoliticaContextFactory.PlayerOne));
        }

        [Fact]
        public async Task CreateUnionCommandHandler_FailOnWrongUnionsId()
        {
            //Arrange
            var handler = new CreateUnionCommandHandler(context);
            var title = "Союз";
            var description = "Описание";
            var coordinates = "2 2";
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
                        Coordinates = coordinates,
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
            var Coordinates = "2 2";

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new CreateUnionCommand
                    {
                        Title = Title,
                        Description = Description,
                        Coordinates = Coordinates,
                        OwnerId = Guid.NewGuid(),
                        Fractions = null,
                    },
                CancellationToken.None);
            });
        }
    }
}
