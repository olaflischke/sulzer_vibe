namespace Northwind.DataAccess.Models;

public sealed class Product
{
    public int ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public int? SupplierId { get; init; }
    public int? CategoryId { get; init; }
    public string? QuantityPerUnit { get; init; }
    public decimal? UnitPrice { get; init; }
    public short? UnitsInStock { get; init; }
    public short? UnitsOnOrder { get; init; }
    public short? ReorderLevel { get; init; }
    public bool Discontinued { get; init; }
}
