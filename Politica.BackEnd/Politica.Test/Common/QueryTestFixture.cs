using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Interfaces;
using Politica.Persistence;
using System;
using Xunit;

namespace Politica.Test.Common
{
    public class QueryTestFixture : IDisposable
    {
        public PoliticaDbContext context;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = PoliticaContextFactory.Create();
            var configurationProvider = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new AssemblyMappingProfile(
                    typeof(IPoliticaDbContext).Assembly));
            });

            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() =>
            PoliticaContextFactory.Destroy(context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}