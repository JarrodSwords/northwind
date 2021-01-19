using Dapper.Contrib.Extensions;
using Northwind.Domain;
using Npgsql;

namespace Northwind.Infrastructure.PostgreSql
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NpgsqlConnection _connection;
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=northwind;User Id=postgres;Password=postgres";

        public OrderRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public Domain.Order Find(int id)
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            var order = connection.Get<Order>(id);

            return order.ToDomain();
        }
    }
}