namespace Northwind.Domain
{
    public interface IOrderService
    {
        void RemoveCustomer(OrderCustomerArgs args);
    }
}