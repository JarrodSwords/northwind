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
            var record = _connection.Get<Order>(id);

            var order = new Domain.Order(
                record.order_id,
                record.customer_id,
                record.employee_id,
                record.order_date,
                record.required_date,
                record.shipped_date,
                record.ship_via,
                record.freight,
                new Address(
                    record.ship_name,
                    record.ship_address,
                    record.ship_city,
                    record.ship_region,
                    record.ship_postal_code,
                    record.ship_country)
            );

            return order;
        }
    }
}