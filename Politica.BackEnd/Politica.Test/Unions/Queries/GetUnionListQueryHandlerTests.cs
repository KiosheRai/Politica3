using AutoMapper;
using Politica.Application.Unions.Queries.GetUnionList;
using Politica.Persistence;
using Politica.Test.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Unions.Queries
{
    [Collection("QueryCollection")]
    public class GetUnionListQueryHandlerTests
    {
        private readonly PoliticaDbContext _context;
        private readonly IMapper _mapper;

        public GetUnionListQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetUnionListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetUnionListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetUnionListQuery { },
                CancellationToken.None);

            //Assert 
            result.ShouldBeOfType<UnionListVm>();
            result.Unions.Count.ShouldBe(3);
        }
    }
}
