using System.Data;
using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;
using Northwind.DataAccess.Helpers;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Repositories;

public sealed class OrderRepository : SqlRepositoryBase<Order, int>, IOrderRepository
{
    public OrderRepository(INorthwindConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public override string TableName => "Orders";

    public override Order Map(IDataRecord record)
    {
        return new Order
        {
            OrderId = record.GetInt32(record.GetOrdinal("OrderID")),
            CustomerId = record.GetNullableString("CustomerID"),
            EmployeeId = record.GetNullableInt32("EmployeeID"),
            OrderDate = record.GetNullableDateTime("OrderDate"),
            RequiredDate = record.GetNullableDateTime("RequiredDate"),
            ShippedDate = record.GetNullableDateTime("ShippedDate"),
            ShipVia = record.GetNullableInt32("ShipVia"),
            Freight = record.GetNullableDecimal("Freight"),
            ShipName = record.GetNullableString("ShipName"),
            ShipAddress = record.GetNullableString("ShipAddress"),
            ShipCity = record.GetNullableString("ShipCity"),
            ShipRegion = record.GetNullableString("ShipRegion"),
            ShipPostalCode = record.GetNullableString("ShipPostalCode"),
            ShipCountry = record.GetNullableString("ShipCountry")
        };
    }

    protected override string BuildSelectAllSql() => "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders";

    protected override string BuildSelectByIdSql() => "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders WHERE OrderID = @OrderID";

    protected override string BuildInsertSql() => "INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";

    protected override string BuildUpdateSql() => "UPDATE Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID = @OrderID";

    protected override string BuildDeleteSql() => "DELETE FROM Orders WHERE OrderID = @OrderID";

    protected override void AddIdParameter(SqlCommand command, int id) =>
        command.Parameters.AddWithValue("@OrderID", id);

    protected override void AddInsertParameters(SqlCommand command, Order entity)
    {
        command.Parameters.AddWithValue("@CustomerID", (object?)entity.CustomerId ?? DBNull.Value);
        command.Parameters.AddWithValue("@EmployeeID", (object?)entity.EmployeeId ?? DBNull.Value);
        command.Parameters.AddWithValue("@OrderDate", (object?)entity.OrderDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@RequiredDate", (object?)entity.RequiredDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShippedDate", (object?)entity.ShippedDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipVia", (object?)entity.ShipVia ?? DBNull.Value);
        command.Parameters.AddWithValue("@Freight", (object?)entity.Freight ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipName", (object?)entity.ShipName ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipAddress", (object?)entity.ShipAddress ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipCity", (object?)entity.ShipCity ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipRegion", (object?)entity.ShipRegion ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipPostalCode", (object?)entity.ShipPostalCode ?? DBNull.Value);
        command.Parameters.AddWithValue("@ShipCountry", (object?)entity.ShipCountry ?? DBNull.Value);
    }

    protected override void AddUpdateParameters(SqlCommand command, Order entity)
    {
        command.Parameters.AddWithValue("@OrderID", entity.OrderId);
        AddInsertParameters(command, entity);
    }
}
