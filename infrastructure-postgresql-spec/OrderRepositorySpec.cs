using FluentAssertions;
using Northwind.Infrastructure.PostgreSql;
using Xunit;

namespace Infrastructure.PostgreSql.Spec
{
    public class OrderRepositorySpec
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=northwind;User Id=postgres;Password=postgres";
        
        [Fact]
        public void WhenFinding_WithId()
        {
            using var uow = new UnitOfWork(ConnectionString);
            var orderRepository = new OrderRepository(uow);

            var order = orderRepository.Find(10248);

            order.Should().NotBeNull();
        }
    }
}