using Microsoft.Extensions.DependencyInjection;
using Northwind.DataAccess.Abstractions;
using Northwind.DataAccess.Factories;
using Northwind.DataAccess.Repositories;

namespace Northwind.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNorthwindDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<INorthwindConnectionFactory>(_ => new NorthwindConnectionFactory(connectionString));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
