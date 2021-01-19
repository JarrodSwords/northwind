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
            return order.ToDomain();
        }
    }
}