namespace Northwind.Domain
{
    public class Customer
    {
        public Customer(
            string id,
            string companyName,
            string contactName,
            string contactTitle,
            Address address,
            string phone,
            string fax
        )
        {
            Id = id;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            Phone = phone;
            Fax = fax;
        }

        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}