using FluentAssertions;
using Northwind.Domain;
using Northwind.Infrastructure.PostgreSql;
using Npgsql;
using Xunit;

namespace Infrastructure.PostgreSql.Spec
{
    public class OrderRepositorySpec
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=northwind;User Id=postgres;Password=postgres";

        private readonly IOrderRepository _orderRepository;

        public OrderRepositorySpec()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                _orderRepository = new OrderRepository(connection);
            }
        }

        [Fact]
        public void WhenFinding_WithId()
        {
            var order = _orderRepository.Find(10248);

            order.Should().NotBeNull();
        }
    }
}