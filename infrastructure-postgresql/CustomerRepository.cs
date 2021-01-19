using Dapper.Contrib.Extensions;
using Northwind.Domain;

namespace Northwind.Infrastructure.PostgreSql
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomerRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Domain.Customer Find(string customerId)
        {
            var source = _unitOfWork.Connection.Get<Customer>(customerId);
            return source.CreateCustomer();
        }
    }
}