using System.Data;

namespace Northwind.DataAccess.Helpers;

internal static class SqlDataRecordExtensions
{
    public static string? GetNullableString(this IDataRecord record, string columnName)
    {
        var ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetString(ordinal);
    }

    public static DateTime? GetNullableDateTime(this IDataRecord record, string columnName)
    {
        var ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetDateTime(ordinal);
    }

    public static int? GetNullableInt32(this IDataRecord record, string columnName)
    {
        var ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetInt32(ordinal);
    }

    public static decimal? GetNullableDecimal(this IDataRecord record, string columnName)
    {
        var ordinal = record.GetOrdinal(columnName);
        return record.IsDBNull(ordinal) ? null : record.GetDecimal(ordinal);
    }

    public static byte[]? GetNullableByteArray(this IDataRecord record, string columnName)
    {
        var ordinal = record.GetOrdinal(columnName);
        if (record.IsDBNull(ordinal))
        {
            return null;
        }

        return (byte[])record.GetValue(ordinal);
    }
}
