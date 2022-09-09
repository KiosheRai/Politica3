using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Unions.Commands.DeleteUnion;
using Politica.Test.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Unions.Commands
{
    public class DeleteUnionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteUnionCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteUnionCommandHandler(context);

            //Act
            await handler.Handle(
                new DeleteUnionCommand
                {
                    Id = PoliticaContextFactory.UnionForDelete
                },
                CancellationToken.None);

            //Assert
            Assert.Null(
                await context.Unions.SingleOrDefaultAsync(x =>
                x.Id == PoliticaContextFactory.UnionForDelete
                && x.IsDeleted == false));
        }

        [Fact]
        public async Task DeleteUnionCommandHandler_FailWrongId()
        {
            //Arrange
            var handler = new DeleteUnionCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteUnionCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
