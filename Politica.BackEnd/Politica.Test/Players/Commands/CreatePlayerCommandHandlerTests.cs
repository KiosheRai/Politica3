using Microsoft.EntityFrameworkCore;
using Politica.Application.Common.Exceptions;
using Politica.Application.Players.Commands.CreatePlayer;
using Politica.Test.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Players.Commands
{
    public class CreatePlayerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePlayerCommandHandler_Success()
        {
            //Arrange
            var handler = new CreatePlayerCommandHandler(context);
            var Name = "Name";
            var Habit = "VK";
            var HabitId = 4123;

            //Act
            var Id = await handler.Handle(
                new CreatePlayerCommand
                {
                   Name = Name,
                   Habit = Habit,
                   HabitId = HabitId,
                   InvitedId = null
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Players.SingleOrDefaultAsync(x =>
                x.Id == Id 
                && x.Name == Name
                && x.Habit == Habit
                && x.HabitId == HabitId));
                
        }

        [Fact]
        public async Task CreatePlayerCommandHandler_SuccessInvitedId()
        {
            //Arrange
            var handler = new CreatePlayerCommandHandler(context);
            var Name = "Name";
            var Habit = "VK";
            var HabitId = 4126;
            var InvitedId = PoliticaContextFactory.InvitedPlayer;

            //Act
            var Id = await handler.Handle(
                new CreatePlayerCommand
                {
                    Name = Name,
                    Habit = Habit,
                    HabitId = HabitId,
                    InvitedId = InvitedId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Players.SingleOrDefaultAsync(x =>
                x.Id == Id
                && x.Name == Name
                && x.Habit == Habit
                && x.HabitId == HabitId
                && x.InvitedId == InvitedId));
        }

        [Fact]
        public async Task CreatePlayerCommandHandler_WrongInvitedId()
        {
            //Arrange
            var handler = new CreatePlayerCommandHandler(context);
            var Name = "Name";
            var Habit = "VK";
            var HabitId = 4123;

            //Act
     
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreatePlayerCommand
                    {
                        Name = Name,
                        Habit = Habit,
                        HabitId = HabitId,
                        InvitedId = System.Guid.NewGuid()
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task CreatePlayerCommandHandler_WrongHabitIdAlreadyExists()
        {
            //Arrange
            var handler = new CreatePlayerCommandHandler(context);
            var Name = "Name";
            var Habit = "VK";

            //Act

            //Assert
            await Assert.ThrowsAsync<AlreadyExistsException>(async () =>
                await handler.Handle(
                    new CreatePlayerCommand
                    {
                        Name = Name,
                        Habit = Habit,
                        HabitId = PoliticaContextFactory.AlreadyExistsHabitId,
                        InvitedId = null
                    },
                    CancellationToken.None));
        }
    }
}
