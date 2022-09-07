using AutoMapper;
using Politica.Application.Players.Queries.GetPlayerList;
using Politica.Persistence;
using Politica.Test.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Politica.Test.Players.Queries
{
    [Collection("QueryCollection")]
    public class GetPlayerListQueryHandlerTests
    {
        private readonly PoliticaDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayerListQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetPlayerListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetPlayerListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetPlayerListQuery { },
                CancellationToken.None);

            //Assert 
            result.ShouldBeOfType<PlayerListVm>();
            result.Players.Count.ShouldBe(5);
        }
    }
}
