using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Fractions.Commands.DeleteFraction;
using Politica.Test.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Fractions.Commands
{
    public class DeleteFractionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFractionCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteFractionCommandHandler(context);

            //Act
            await handler.Handle(
                new DeleteFractionCommand
                {
                    Id = PoliticaContextFactory.FractionForDelete
                },
                CancellationToken.None);

            //Assert
            Assert.Null(
                await context.Fractions.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.FractionForDelete
                && x.IsDeleted == false));
        }

        [Fact]
        public async Task DeleteFractionCommandHandler_FailWrongId()
        {
            //Arrange
            var handler = new DeleteFractionCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFractionCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
