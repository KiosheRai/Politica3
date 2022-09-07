using Politica.Persistence;
using System;

namespace Politica.Test.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly PoliticaDbContext context;

        public TestCommandBase() =>
            context = PoliticaContextFactory.Create();


        public void Dispose() =>
            PoliticaContextFactory.Destroy(context);
    }
}
