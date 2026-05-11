using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Abstractions;

public interface IOrderRepository : IRepository<Order, int>
{
}
