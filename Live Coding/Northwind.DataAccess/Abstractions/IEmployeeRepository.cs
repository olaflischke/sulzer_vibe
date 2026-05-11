using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Abstractions;

public interface IEmployeeRepository : IRepository<Employee, int>
{
}
