using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Abstractions;

public interface ICustomerRepository : IRepository<Customer, string>
{
}
