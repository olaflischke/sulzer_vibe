using System.Data;
using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;
using Northwind.DataAccess.Helpers;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Repositories;

public sealed class EmployeeRepository : SqlRepositoryBase<Employee, int>, IEmployeeRepository
{
    public EmployeeRepository(INorthwindConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public override string TableName => "Employees";

    public override Employee Map(IDataRecord record)
    {
        return new Employee
        {
            EmployeeId = record.GetInt32(record.GetOrdinal("EmployeeID")),
            LastName = record.GetString(record.GetOrdinal("LastName")),
            FirstName = record.GetString(record.GetOrdinal("FirstName")),
            Title = record.GetNullableString("Title"),
            TitleOfCourtesy = record.GetNullableString("TitleOfCourtesy"),
            BirthDate = record.GetNullableDateTime("BirthDate"),
            HireDate = record.GetNullableDateTime("HireDate"),
            Address = record.GetNullableString("Address"),
            City = record.GetNullableString("City"),
            Region = record.GetNullableString("Region"),
            PostalCode = record.GetNullableString("PostalCode"),
            Country = record.GetNullableString("Country"),
            HomePhone = record.GetNullableString("HomePhone"),
            Extension = record.GetNullableString("Extension"),
            Photo = record.GetNullableByteArray("Photo"),
            Notes = record.GetNullableString("Notes"),
            ReportsTo = record.GetNullableInt32("ReportsTo"),
            PhotoPath = record.GetNullableString("PhotoPath")
        };
    }

    protected override string BuildSelectAllSql() => "SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath FROM Employees";

    protected override string BuildSelectByIdSql() => "SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath FROM Employees WHERE EmployeeID = @EmployeeID";

    protected override string BuildInsertSql() => "INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath) VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath)";

    protected override string BuildUpdateSql() => "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title, TitleOfCourtesy = @TitleOfCourtesy, BirthDate = @BirthDate, HireDate = @HireDate, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, HomePhone = @HomePhone, Extension = @Extension, Photo = @Photo, Notes = @Notes, ReportsTo = @ReportsTo, PhotoPath = @PhotoPath WHERE EmployeeID = @EmployeeID";

    protected override string BuildDeleteSql() => "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

    protected override void AddIdParameter(SqlCommand command, int id) =>
        command.Parameters.AddWithValue("@EmployeeID", id);

    protected override void AddInsertParameters(SqlCommand command, Employee entity)
    {
        command.Parameters.AddWithValue("@LastName", entity.LastName);
        command.Parameters.AddWithValue("@FirstName", entity.FirstName);
        command.Parameters.AddWithValue("@Title", (object?)entity.Title ?? DBNull.Value);
        command.Parameters.AddWithValue("@TitleOfCourtesy", (object?)entity.TitleOfCourtesy ?? DBNull.Value);
        command.Parameters.AddWithValue("@BirthDate", (object?)entity.BirthDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@HireDate", (object?)entity.HireDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@Address", (object?)entity.Address ?? DBNull.Value);
        command.Parameters.AddWithValue("@City", (object?)entity.City ?? DBNull.Value);
        command.Parameters.AddWithValue("@Region", (object?)entity.Region ?? DBNull.Value);
        command.Parameters.AddWithValue("@PostalCode", (object?)entity.PostalCode ?? DBNull.Value);
        command.Parameters.AddWithValue("@Country", (object?)entity.Country ?? DBNull.Value);
        command.Parameters.AddWithValue("@HomePhone", (object?)entity.HomePhone ?? DBNull.Value);
        command.Parameters.AddWithValue("@Extension", (object?)entity.Extension ?? DBNull.Value);
        command.Parameters.AddWithValue("@Photo", (object?)entity.Photo ?? DBNull.Value);
        command.Parameters.AddWithValue("@Notes", (object?)entity.Notes ?? DBNull.Value);
        command.Parameters.AddWithValue("@ReportsTo", (object?)entity.ReportsTo ?? DBNull.Value);
        command.Parameters.AddWithValue("@PhotoPath", (object?)entity.PhotoPath ?? DBNull.Value);
    }

    protected override void AddUpdateParameters(SqlCommand command, Employee entity)
    {
        command.Parameters.AddWithValue("@EmployeeID", entity.EmployeeId);
        AddInsertParameters(command, entity);
    }
}
