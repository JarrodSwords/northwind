using System;
using Northwind.Domain;

namespace Domain.Spec
{
    internal class ObjectProvider
    {
        public static Order GetOrder()
        {
            var mockDate = DateTime.Now;
            return new Order(1, 1, mockDate, mockDate, mockDate, 1, 1, "", GetAddress(), null);
        }

        public static Address GetAddress()
        {
            return new("", "", "", "", "");
        }

        public static Customer GetCustomer()
        {
            return new("cust1", "", "", "", GetAddress(), "", "");
        }
    }
}