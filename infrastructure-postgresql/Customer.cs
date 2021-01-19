using Dapper.Contrib.Extensions;
using Northwind.Domain;

namespace Northwind.Infrastructure.PostgreSql
{
    public class Customer
    {
        [Key] public string customer_id { get; set; }
        public string company_name { get; set; }
        public string contact_name { get; set; }
        public string contact_title { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }

        public Domain.Customer CreateCustomer()
        {
            return new(
                customer_id,
                company_name,
                contact_name,
                contact_title,
                CreateAddress(),
                phone,
                fax
            );
        }

        private Address CreateAddress()
        {
            return new(address, city, region, postal_code, country);
        }
    }
}