namespace Northwind.DataAccess.Models;

public sealed class Category
{
    public int CategoryId { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public byte[]? Picture { get; init; }
}
