using CrossTools.ConnectionStringFactory;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Persistence.Review.Context
{
    public class ReviewContext : DbContext
    {
        private readonly SqlConnection _connection;
        private readonly IConnectionStringFactory _connectionStringFactory;

        public DbSet<Model.Review> Review { get; set; }

        public ReviewContext(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
    }
}
