using CrossTools.ConnectionStringFactory;
using Persistence.BurgerRestaurant.Model;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Persistence.BurgerRestaurant.Context
{
    public class RestaurantContext : DbContext
    {
        private readonly SqlConnection _connection;
        private readonly IConnectionStringFactory _connectionStringFactory;
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestaurantContext(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
    }
}