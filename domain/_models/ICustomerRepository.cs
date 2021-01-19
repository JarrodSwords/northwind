namespace Northwind.Domain
{
    public interface ICustomerRepository
    {
        Customer Find(string customerId);
    }
}