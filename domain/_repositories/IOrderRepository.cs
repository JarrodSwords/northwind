namespace Northwind.Domain
{
    public interface IOrderRepository
    {
        Order Find(int id);
        void Update(Order order);
    }
}