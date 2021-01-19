using FluentAssertions;
using Northwind.Domain;
using Xunit;

namespace Domain.Spec
{
    public class OrderSpec
    {
        [Theory]
        [InlineData("cust2")]
        public void WhenAssigningCustomer(string customerId)
        {
            var order = ObjectProvider.GetOrder();
            var customer = new Customer(customerId, "", "", "", ObjectProvider.GetAddress(), "", "");

            order.Assign(customer);

            order.Customer.Should().Be(customer);
            order.CustomerId.Should().Be(customer.Id);
            order.HasCustomer.Should().BeTrue();
        }

        [Fact]
        public void WhenRemovingCustomer_CustomerIsNull()
        {
            var order = ObjectProvider.GetOrder();
            var customer = ObjectProvider.GetCustomer();
            order.Assign(customer);

            order.RemoveCustomer(customer.Id);

            order.Customer.Should().BeNull();
            order.CustomerId.Should().BeNull();
            order.HasCustomer.Should().BeFalse();
        }
    }
}