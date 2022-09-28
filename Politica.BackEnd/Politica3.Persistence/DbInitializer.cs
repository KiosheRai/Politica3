namespace Politica.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(PoliticaDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
