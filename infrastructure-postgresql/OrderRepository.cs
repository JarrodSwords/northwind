using Dapper.Contrib.Extensions;
using Northwind.Domain;

namespace Northwind.Infrastructure.PostgreSql
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.Order Find(int id)
        {
            var order = _unitOfWork.Connection.Get<Order>(id);
            order.Customer = _unitOfWork.Connection.Get<Customer>(order.customer_id);
            return order.CreateOrder();
        }

        public void Update(Domain.Order order)
        {
            var source = Find(order.Id);

            if (source == order)
                return;

            var dbOrder = new Order(order);
            _unitOfWork.Connection.Update(dbOrder);
        }
    }
}