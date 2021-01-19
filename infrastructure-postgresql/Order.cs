using System;
using Dapper.Contrib.Extensions;
using Northwind.Domain;

namespace Northwind.Infrastructure.PostgreSql
{
    public class Order
    {
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
        public Customer Customer { get; set; }

        public Domain.Order CreateOrder()
        {
            return new(
                order_id,
                customer_id,
                employee_id,
                order_date,
                required_date,
                shipped_date,
                ship_via,
                freight,
                ship_name,
                CreateAddress(),
                Customer.CreateCustomer()
            );
        }

        private Address CreateAddress()
        {
            return new(ship_address, ship_city, ship_region, ship_postal_code, ship_country);
        }
    }
}