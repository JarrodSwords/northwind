namespace Northwind.Domain
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository
        )
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public void RemoveCustomer(OrderCustomerArgs args)
        {
            var order = _orderRepository.Find(args.OrderId);

            order.RemoveCustomer(args.CustomerId);

            _orderRepository.Update(order);
        }

        public void AssignCustomer(OrderCustomerArgs args)
        {
            var order = _orderRepository.Find(args.OrderId);
            var customer = _customerRepository.Find(args.CustomerId);

            order.Assign(customer);

            _orderRepository.Update(order);
        }
    }
}