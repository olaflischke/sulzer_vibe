using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Abstractions;

public interface ICategoryRepository : IRepository<Category, int>
{
}
