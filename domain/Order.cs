using System;

namespace Northwind.Domain
{
    public class Order
    {
        public Order(
            int id,
            string customerId,
            int employeeId,
            DateTime orderDate,
            DateTime requiredDate,
            DateTime shippedDate,
            int shipVia,
            float freight,
            string shipName,
            Address address,
            Customer customer
        )
        {
            Id = id;
            CustomerId = customerId;
            EmployeeId = employeeId;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            ShipVia = shipVia;
            Freight = freight;
            ShipName = shipName;
            Address = address;
            Customer = customer;
        }

        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public float Freight { get; set; }
        public string ShipName { get; set; }
        public Address Address { get; set; }
        public Customer Customer { get; set; }
    }
}