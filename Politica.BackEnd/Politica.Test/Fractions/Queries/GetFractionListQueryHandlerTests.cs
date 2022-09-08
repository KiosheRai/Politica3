using AutoMapper;
using Politica.Application.Fractions.Queries.GetFractionList;
using Politica.Persistence;
using Politica.Test.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Fractions.Queries
{
    [Collection("QueryCollection")]
    public class GetFractionListQueryHandlerTests
    {
        private readonly PoliticaDbContext _context;
        private readonly IMapper _mapper;

        public GetFractionListQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetFractionListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetFractionListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetFractionListQuery { },
                CancellationToken.None);

            //Assert 
            result.ShouldBeOfType<FractionListVm>();
            result.Fractions.Count.ShouldBe(4);
        }
    }
}
