using System.Data;
using Microsoft.Data.SqlClient;
using Northwind.DataAccess.Abstractions;

namespace Northwind.DataAccess.Repositories;

public abstract class SqlRepositoryBase<TEntity, TKey> : ISqlRepository<TEntity, TKey>
    where TEntity : class
{
    private readonly INorthwindConnectionFactory _connectionFactory;

    protected SqlRepositoryBase(INorthwindConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public abstract string TableName { get; }

    public abstract TEntity Map(IDataRecord record);

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = BuildSelectAllSql();

        var results = new List<TEntity>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
        {
            results.Add(Map(reader));
        }

        return results;
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = BuildSelectByIdSql();
        AddIdParameter(command, id);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
        {
            return Map(reader);
        }

        return null;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = BuildInsertSql();
        AddInsertParameters(command, entity);
        await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = BuildUpdateSql();
        AddUpdateParameters(command, entity);
        await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
        await using var command = connection.CreateCommand();
        command.CommandText = BuildDeleteSql();
        AddIdParameter(command, id);
        await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    protected abstract string BuildSelectAllSql();
    protected abstract string BuildSelectByIdSql();
    protected abstract string BuildInsertSql();
    protected abstract string BuildUpdateSql();
    protected abstract string BuildDeleteSql();
    protected abstract void AddIdParameter(SqlCommand command, TKey id);
    protected abstract void AddInsertParameters(SqlCommand command, TEntity entity);
    protected abstract void AddUpdateParameters(SqlCommand command, TEntity entity);

    TEntity ISqlRepository<TEntity, TKey>.Map(System.Data.Common.DbDataReader reader) => Map(reader);
}
