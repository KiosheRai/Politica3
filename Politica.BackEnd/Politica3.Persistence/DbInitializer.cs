namespace Politica.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PoliticaDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
