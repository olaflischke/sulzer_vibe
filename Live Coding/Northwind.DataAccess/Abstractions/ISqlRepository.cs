using System.Data.Common;

namespace Northwind.DataAccess.Abstractions;

public interface ISqlRepository<TEntity, in TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{
    string TableName { get; }
    TEntity Map(DbDataReader reader);
}
