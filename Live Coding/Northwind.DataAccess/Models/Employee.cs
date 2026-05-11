namespace Northwind.DataAccess.Models;

public sealed class Employee
{
    public int EmployeeId { get; init; }
    public string LastName { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string? Title { get; init; }
    public string? TitleOfCourtesy { get; init; }
    public DateTime? BirthDate { get; init; }
    public DateTime? HireDate { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? PostalCode { get; init; }
    public string? Country { get; init; }
    public string? HomePhone { get; init; }
    public string? Extension { get; init; }
    public byte[]? Photo { get; init; }
    public string? Notes { get; init; }
    public int? ReportsTo { get; init; }
    public string? PhotoPath { get; init; }
}
