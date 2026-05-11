using System.Data;
using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;
using Northwind.DataAccess.Helpers;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Repositories;

public sealed class CustomerRepository : SqlRepositoryBase<Customer, string>, ICustomerRepository
{
    public CustomerRepository(INorthwindConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public override string TableName => "Customers";

    public override Customer Map(IDataRecord record)
    {
        return new Customer
        {
            CustomerId = record.GetString(record.GetOrdinal("CustomerID")),
            CompanyName = record.GetString(record.GetOrdinal("CompanyName")),
            ContactName = record.GetNullableString("ContactName"),
            ContactTitle = record.GetNullableString("ContactTitle"),
            Address = record.GetNullableString("Address"),
            City = record.GetNullableString("City"),
            Region = record.GetNullableString("Region"),
            PostalCode = record.GetNullableString("PostalCode"),
            Country = record.GetNullableString("Country"),
            Phone = record.GetNullableString("Phone"),
            Fax = record.GetNullableString("Fax")
        };
    }

    protected override string BuildSelectAllSql() => "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers";

    protected override string BuildSelectByIdSql() => "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers WHERE CustomerID = @CustomerID";

    protected override string BuildInsertSql() => "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

    protected override string BuildUpdateSql() => "UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax WHERE CustomerID = @CustomerID";

    protected override string BuildDeleteSql() => "DELETE FROM Customers WHERE CustomerID = @CustomerID";

    protected override void AddIdParameter(SqlCommand command, string id) =>
        command.Parameters.AddWithValue("@CustomerID", id);

    protected override void AddInsertParameters(SqlCommand command, Customer entity)
    {
        command.Parameters.AddWithValue("@CustomerID", entity.CustomerId);
        command.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
        command.Parameters.AddWithValue("@ContactName", (object?)entity.ContactName ?? DBNull.Value);
        command.Parameters.AddWithValue("@ContactTitle", (object?)entity.ContactTitle ?? DBNull.Value);
        command.Parameters.AddWithValue("@Address", (object?)entity.Address ?? DBNull.Value);
        command.Parameters.AddWithValue("@City", (object?)entity.City ?? DBNull.Value);
        command.Parameters.AddWithValue("@Region", (object?)entity.Region ?? DBNull.Value);
        command.Parameters.AddWithValue("@PostalCode", (object?)entity.PostalCode ?? DBNull.Value);
        command.Parameters.AddWithValue("@Country", (object?)entity.Country ?? DBNull.Value);
        command.Parameters.AddWithValue("@Phone", (object?)entity.Phone ?? DBNull.Value);
        command.Parameters.AddWithValue("@Fax", (object?)entity.Fax ?? DBNull.Value);
    }

    protected override void AddUpdateParameters(SqlCommand command, Customer entity)
    {
        AddInsertParameters(command, entity);
    }
}
