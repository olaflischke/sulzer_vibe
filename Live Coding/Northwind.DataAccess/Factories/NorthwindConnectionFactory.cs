using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;

namespace Northwind.DataAccess.Factories;

public sealed class NorthwindConnectionFactory : INorthwindConnectionFactory
{
    private readonly string _connectionString;

    public NorthwindConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<SqlConnection> CreateOpenConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        return connection;
    }
}
