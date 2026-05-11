using System.Data;
using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;
using Northwind.DataAccess.Helpers;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Repositories;

public sealed class ProductRepository : SqlRepositoryBase<Product, int>, IProductRepository
{
    public ProductRepository(INorthwindConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public override string TableName => "Products";

    public override Product Map(IDataRecord record)
    {
        return new Product
        {
            ProductId = record.GetInt32(record.GetOrdinal("ProductID")),
            ProductName = record.GetString(record.GetOrdinal("ProductName")),
            SupplierId = record.IsDBNull(record.GetOrdinal("SupplierID")) ? null : record.GetInt32(record.GetOrdinal("SupplierID")),
            CategoryId = record.IsDBNull(record.GetOrdinal("CategoryID")) ? null : record.GetInt32(record.GetOrdinal("CategoryID")),
            QuantityPerUnit = record.GetNullableString("QuantityPerUnit"),
            UnitPrice = record.IsDBNull(record.GetOrdinal("UnitPrice")) ? null : record.GetDecimal(record.GetOrdinal("UnitPrice")),
            UnitsInStock = record.IsDBNull(record.GetOrdinal("UnitsInStock")) ? null : record.GetInt16(record.GetOrdinal("UnitsInStock")),
            UnitsOnOrder = record.IsDBNull(record.GetOrdinal("UnitsOnOrder")) ? null : record.GetInt16(record.GetOrdinal("UnitsOnOrder")),
            ReorderLevel = record.IsDBNull(record.GetOrdinal("ReorderLevel")) ? null : record.GetInt16(record.GetOrdinal("ReorderLevel")),
            Discontinued = record.GetBoolean(record.GetOrdinal("Discontinued"))
        };
    }

    protected override string BuildSelectAllSql() =>
        "SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products";

    protected override string BuildSelectByIdSql() =>
        "SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products WHERE ProductID = @ProductID";

    protected override string BuildInsertSql() =>
        "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";

    protected override string BuildUpdateSql() =>
        "UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued WHERE ProductID = @ProductID";

    protected override string BuildDeleteSql() =>
        "DELETE FROM Products WHERE ProductID = @ProductID";

    protected override void AddIdParameter(SqlCommand command, int id) =>
        command.Parameters.AddWithValue("@ProductID", id);

    protected override void AddInsertParameters(SqlCommand command, Product entity)
    {
        command.Parameters.AddWithValue("@ProductName", entity.ProductName);
        command.Parameters.AddWithValue("@SupplierID", (object?)entity.SupplierId ?? DBNull.Value);
        command.Parameters.AddWithValue("@CategoryID", (object?)entity.CategoryId ?? DBNull.Value);
        command.Parameters.AddWithValue("@QuantityPerUnit", (object?)entity.QuantityPerUnit ?? DBNull.Value);
        command.Parameters.AddWithValue("@UnitPrice", (object?)entity.UnitPrice ?? DBNull.Value);
        command.Parameters.AddWithValue("@UnitsInStock", (object?)entity.UnitsInStock ?? DBNull.Value);
        command.Parameters.AddWithValue("@UnitsOnOrder", (object?)entity.UnitsOnOrder ?? DBNull.Value);
        command.Parameters.AddWithValue("@ReorderLevel", (object?)entity.ReorderLevel ?? DBNull.Value);
        command.Parameters.AddWithValue("@Discontinued", entity.Discontinued);
    }

    protected override void AddUpdateParameters(SqlCommand command, Product entity)
    {
        command.Parameters.AddWithValue("@ProductID", entity.ProductId);
        AddInsertParameters(command, entity);
    }
}
