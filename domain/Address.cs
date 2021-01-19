namespace Northwind.Domain
{
    public class Address
    {
        public Address(
            string name,
            string streetAddress,
            string city,
            string region,
            string postalCode,
            string country)
        {
            Name = name;
            StreetAddress = streetAddress;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
        }

        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}