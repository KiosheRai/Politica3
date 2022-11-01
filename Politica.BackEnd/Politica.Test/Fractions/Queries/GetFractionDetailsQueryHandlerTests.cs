using AutoMapper;
using Politica.Application.Fractions.Queries.GetFractionDetails;
using Politica.Domain;
using Politica.Persistence;
using Politica.Test.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Fractions.Queries
{
    [Collection("QueryCollection")]
    public class GetFractionDetailsQueryHandlerTests
    {
        private readonly PoliticaDbContext _context;
        private readonly IMapper _mapper;

        public GetFractionDetailsQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetFractionDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetFractionDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetFractionDetailsQuery
                {
                    Id = PoliticaContextFactory.FractionForDetails
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<FractionDetailsVm>();
            result.Title.ShouldBe("FractionForDetails");
            result.Description.ShouldBe("Описание");
            result.CoordinateX.ShouldBe(123);
            result.CoordinateZ.ShouldBe(321231);
            result.OwnerId.ShouldBe(PoliticaContextFactory.PlayerFractionOwner);
            result.Association.ShouldBe(null);
        }
    }
}
