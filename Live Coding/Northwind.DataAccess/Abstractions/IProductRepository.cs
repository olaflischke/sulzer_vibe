using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Abstractions;

public interface IProductRepository : IRepository<Product, int>
{
}
