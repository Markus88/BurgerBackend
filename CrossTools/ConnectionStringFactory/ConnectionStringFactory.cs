namespace CrossTools.ConnectionStringFactory
{
    public class ConnectionStringFactory : IConnectionStringFactory
    {

        public ConnectionStringFactory() { }

        public string SqlServer => "DESKTOP-24NR8VJ";
        public string SqlDatabase => "BurgerBackendDb";

        public string Create()
        {
            return $"Integrated Security=SSPI;MultipleActiveResultSets=True;Server={SqlServer};database={SqlDatabase};";
        }
    }
}