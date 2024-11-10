using Npgsql;

namespace LibraryApiExample.Database
{
    public class DataSource
    {
        private static readonly DataSource _instance = new DataSource();
        public NpgsqlDataSource Source { get; private set; }

        private DataSource()
        {
            Source = NpgsqlDataSource.Create("Host=localhost;Port=5432;Username=postgres;Password=root;Database=library");
        }

        public static DataSource Instance()
        {
            return _instance;
        }
    }
}
