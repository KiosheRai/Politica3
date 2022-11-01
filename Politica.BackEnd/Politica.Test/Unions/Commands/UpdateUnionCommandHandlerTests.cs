using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Unions.Commands.UpdateUnion;
using Politica.Domain;
using Politica.Test.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Unions.Commands
{
    public class UpdateUnionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateUnionCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateUnionCommandHandler(context);
            var Title = "New Title";
            var Description = "New description";
            var coordinateX = 100;
            var coordinateZ = 100;

            //Act
            await handler.Handle(
                new UpdateUnionCommand
                {
                    Id = PoliticaContextFactory.UnionForUpdate,
                    Title = Title,
                    Description = Description,
                    CoordinateX = coordinateX,
                    CoordinateZ = coordinateZ,
                    OwnerId = PoliticaContextFactory.PlayerFractionOwner
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Unions.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.UnionForUpdate
                && x.Title == Title
                && x.Description == Description
                && x.CoordinateX == coordinateX
                && x.CoordinateZ == coordinateZ
                && x.OwnerId == PoliticaContextFactory.PlayerFractionOwner));
        }

        [Fact]
        public async Task UpdateUnionCommandHandler_FailUnionId()
        {
            //Arrange
            var handler = new UpdateUnionCommandHandler(context);
            var Title = "New Title";
            var Description = "New description";
            var coordinateX = 100;
            var coordinateZ = 100;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateUnionCommand
                    {
                        Id = Guid.NewGuid(),
                        Title = Title,
                        Description = Description,
                        CoordinateX = coordinateX,
                        CoordinateZ = coordinateZ,
                        OwnerId = PoliticaContextFactory.PlayerFractionOwner
                    },
                CancellationToken.None));
        }

        [Fact]
        public async Task UpdateUnionCommandHandler_FailOwnerIdChange()
        {
            //Arrange
            var handler = new UpdateUnionCommandHandler(context);
            var Title = "New Title";
            var Description = "New description";
            var coordinateX = 100;
            var coordinateZ = 100;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateUnionCommand
                    {
                        Id = PoliticaContextFactory.UnionForUpdate,
                        Title = Title,
                        Description = Description,
                        CoordinateX = coordinateX,
                        CoordinateZ = coordinateZ,
                        OwnerId = Guid.NewGuid()
                    },
                CancellationToken.None));
        }
    }
}
