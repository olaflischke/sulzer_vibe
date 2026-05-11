using System.Data;
using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;
using Northwind.DataAccess.Helpers;
using Northwind.DataAccess.Models;

namespace Northwind.DataAccess.Repositories;

public sealed class CategoryRepository : SqlRepositoryBase<Category, int>, ICategoryRepository
{
    public CategoryRepository(INorthwindConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public override string TableName => "Categories";

    public override Category Map(IDataRecord record)
    {
        return new Category
        {
            CategoryId = record.GetInt32(record.GetOrdinal("CategoryID")),
            CategoryName = record.GetString(record.GetOrdinal("CategoryName")),
            Description = record.GetNullableString("Description"),
            Picture = record.GetNullableByteArray("Picture")
        };
    }

    protected override string BuildSelectAllSql() => "SELECT CategoryID, CategoryName, Description, Picture FROM Categories";

    protected override string BuildSelectByIdSql() => "SELECT CategoryID, CategoryName, Description, Picture FROM Categories WHERE CategoryID = @CategoryID";

    protected override string BuildInsertSql() => "INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@CategoryName, @Description, @Picture)";

    protected override string BuildUpdateSql() => "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description, Picture = @Picture WHERE CategoryID = @CategoryID";

    protected override string BuildDeleteSql() => "DELETE FROM Categories WHERE CategoryID = @CategoryID";

    protected override void AddIdParameter(SqlCommand command, int id) =>
        command.Parameters.AddWithValue("@CategoryID", id);

    protected override void AddInsertParameters(SqlCommand command, Category entity)
    {
        command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
        command.Parameters.AddWithValue("@Description", (object?)entity.Description ?? DBNull.Value);
        command.Parameters.AddWithValue("@Picture", (object?)entity.Picture ?? DBNull.Value);
    }

    protected override void AddUpdateParameters(SqlCommand command, Category entity)
    {
        command.Parameters.AddWithValue("@CategoryID", entity.CategoryId);
        AddInsertParameters(command, entity);
    }
}
