using System.Diagnostics;
using System.Runtime.Versioning;
using FluentAssertions;
using Northwind.Domain;
using Northwind.Infrastructure.PostgreSql;
using Xunit;

namespace Domain.Spec
{
    public class OrderServiceTest
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=northwind;User Id=postgres;Password=postgres";

        [Theory]
        [InlineData(10248, "VINET")]
        public void WhenRemovingCustomer(int orderId, string customerId)
        {
            var uow = new UnitOfWork(ConnectionString);
            var orderRepository = new OrderRepository(uow);
            var customerRepository = new CustomerRepository(uow);
            var orderService = new OrderService(orderRepository, customerRepository);
            var args = new OrderCustomerArgs(orderId, customerId);
            var source = orderRepository.Find(orderId);

            if (!source.HasCustomer)
                orderService.AssignCustomer(args);
            
            orderService.RemoveCustomer(args);
            
            var updatedOrder = orderRepository.Find(orderId);
            updatedOrder.Customer.Should().BeNull();
            updatedOrder.CustomerId.Should().BeNull();
        }

        [Theory]
        [InlineData(10248, "VINET")]
        public void WhenAddingCustomer(int orderId, string customerId)
        {
            var uow = new UnitOfWork(ConnectionString);
            var orderRepository = new OrderRepository(uow);
            var customerRepository = new CustomerRepository(uow);
            var orderService = new OrderService(orderRepository, customerRepository);
            var args = new OrderCustomerArgs(orderId, customerId);
            var source = orderRepository.Find(orderId);

            if (source.HasCustomer)
                orderService.RemoveCustomer(args);

            orderService.AssignCustomer(args);

            var updatedOrder = orderRepository.Find(orderId);
            updatedOrder.Customer.Should().NotBeNull();
            updatedOrder.CustomerId.Should().Be(customerId);
        }
    }
}