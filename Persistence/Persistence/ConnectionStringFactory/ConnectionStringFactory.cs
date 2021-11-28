namespace Persistence.ConnectionStringFactory
{
    public class ConnectionStringFactory : IConnectionStringFactory
    {
        private readonly string _connectionString;

        public ConnectionStringFactory()
        {
            _connectionString = "Integrated Security=true;MultipleActiveResultSets=True;Server=DESKTOP-24NR8VJ;database=BurgerBackendDb;";
        }
        public string Create()
        {
            return _connectionString;
        }
    }
}