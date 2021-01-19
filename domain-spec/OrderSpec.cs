using System;
using System.Runtime.InteropServices;
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
            var order = CreateOrder();
            var customer = new Customer(customerId, "", "", "", CreateAddress(), "", "");

            order.Assign(customer);

            order.Customer.Should().Be(customer);
            order.CustomerId.Should().Be(customer.Id);
        }

        [Fact]
        public void WhenRemovingCustomer_CustomerIsNull()
        {
            var order = CreateOrder();
            var customer = CreateCustomer();
            order.Assign(customer);

            order.RemoveCustomer(customer.Id);

            order.Customer.Should().BeNull();
            order.CustomerId.Should().BeNull();
        }

        private Order CreateOrder()
        {
            var mockDate = DateTime.Now;
            return new Order(1, 1, mockDate, mockDate, mockDate, 1, 1, "", CreateAddress(), null);
        }

        private Address CreateAddress()
        {
            return new ("", "", "", "", "");
        }

        private Customer CreateCustomer()
        {
            return new Customer("cust1", "", "", "", CreateAddress(), "", "");
        }
    }
}