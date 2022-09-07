using AutoMapper;
using Politica.Application.Players.Queries.GetPlayerDetails;
using Politica.Persistence;
using Politica.Test.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Players.Queries
{
    [Collection("QueryCollection")]
    public class GetPlayerDetailsQueryHandlerTests
    {
        private readonly PoliticaDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayerDetailsQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetPlayerDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetPlayerDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetPlayerDetailsQuery
                {
                    Id = PoliticaContextFactory.PlayerForDetails
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<PlayerDetailsVm>();
            result.Name.ShouldBe("Саня");
            result.Habit.ShouldBe("VK");
            result.HabitId.ShouldBe(76756);
            result.InvitedId.ShouldBe(null);
            result.Association.ShouldBe(null);
            result.NickChangeDate.ShouldBe(PoliticaContextFactory.NickChangeDate);
        }
    }
}
