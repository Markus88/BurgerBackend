using Persistence.ConnectionStringFactory;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Persistence.User.Context
{
    public class UserContext : DbContext
    {
        private readonly SqlConnection _connection;
        private readonly IConnectionStringFactory _connectionStringFactory;

        public DbSet<Model.User> User { get; set; }

        public UserContext(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
    }
}