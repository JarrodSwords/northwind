using System;
using Dapper.Contrib.Extensions;
using Northwind.Domain;

namespace Northwind.Infrastructure.PostgreSql
{
    public class Order
    {
        public Order()
        {
        }

        public Order(Domain.Order order)
        {
            order_id = order.Id;
            customer_id = order.CustomerId;
            employee_id = order.EmployeeId;
            order_date = order.OrderDate;
            required_date = order.RequiredDate;
            shipped_date = order.ShippedDate;
            ship_via = order.ShipVia;
            freight = order.Freight;
            ship_name = order.ShipName;
            ship_address = order.Address.StreetAddress;
            ship_city = order.Address.City;
            ship_region = order.Address.Region;
            ship_postal_code = order.Address.PostalCode;
            ship_country = order.Address.Country;
        }

        [Key] public int order_id { get; set; }
        public string customer_id { get; set; }
        public int employee_id { get; set; }
        public DateTime order_date { get; set; }
        public DateTime required_date { get; set; }
        public DateTime shipped_date { get; set; }
        public int ship_via { get; set; }
        public float freight { get; set; }
        public string ship_name { get; set; }
        public string ship_address { get; set; }
        public string ship_city { get; set; }
        public string ship_region { get; set; }
        public string ship_postal_code { get; set; }
        public string ship_country { get; set; }

        [Write(false)]
        public Customer Customer { get; set; }

        public Domain.Order CreateOrder()
        {
            return new(
                order_id,
                employee_id,
                order_date,
                required_date,
                shipped_date,
                ship_via,
                freight,
                ship_name,
                CreateAddress(),
                Customer?.CreateCustomer()
            );
        }

        private Address CreateAddress()
        {
            return new(ship_address, ship_city, ship_region, ship_postal_code, ship_country);
        }
    }
}