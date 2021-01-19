using Dapper.Contrib.Extensions;
using Northwind.Domain;
using Npgsql;

namespace Northwind.Infrastructure.PostgreSql
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NpgsqlConnection _connection;

        public OrderRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public Domain.Order Find(int id)
        {
            return _connection.Get<Order>(id).ToDomain();
        }
    }
}