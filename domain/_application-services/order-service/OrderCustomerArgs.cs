namespace Northwind.Domain
{
    public class OrderCustomerArgs
    {
        public OrderCustomerArgs(int orderId, string customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

        public int OrderId { get; }
        public string CustomerId { get; }
    }
}