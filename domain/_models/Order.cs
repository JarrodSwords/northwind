using System;

namespace Northwind.Domain
{
    public class Order
    {
        public Order(
            int id,
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
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public float Freight { get; set; }
        public string ShipName { get; set; }
        public Address Address { get; set; }

        public Customer Customer { get; private set; }
        public string CustomerId => Customer?.Id;
        public bool HasCustomer => Customer != null;

        public void Assign(Customer customer)
        {
            Customer = customer;
        }

        public void RemoveCustomer(string customerId)
        {
            if (customerId != CustomerId)
                return;

            Customer = null;
        }
    }
}