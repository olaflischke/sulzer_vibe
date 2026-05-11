using Microsoft.Data.SqlClient;

namespace Northwind.DataAccess.Abstractions;

public interface INorthwindConnectionFactory
{
    Task<SqlConnection> CreateOpenConnectionAsync(CancellationToken cancellationToken = default);
}
