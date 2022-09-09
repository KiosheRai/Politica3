using AutoMapper;
using Politica.Application.Unions.Queries.GetUnionDetails;
using Politica.Persistence;
using Politica.Test.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Unions.Queries
{
    [Collection("QueryCollection")]
    public class GetUnionDetailsQueryHandlerTests
    {
        private readonly PoliticaDbContext _context;
        private readonly IMapper _mapper;

        public GetUnionDetailsQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetUnionDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetUnionDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetUnionDetailsQuery
                {
                    Id = PoliticaContextFactory.UnionForDetails
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<UnionDetailsVm>();
            result.Title.ShouldBe("UnionForDetails");
            result.Description.ShouldBe("Описание");
            result.Coordinates.ShouldBe("321 312");
            result.OwnerId.ShouldBe(PoliticaContextFactory.PlayerFractionOwner);
        }
    }
}
