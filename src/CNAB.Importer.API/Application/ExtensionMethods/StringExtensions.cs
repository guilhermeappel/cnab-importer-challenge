using System.Globalization;

namespace CNAB.Importer.API.Application.ExtensionMethods;

public static class StringExtensions
{
    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        return char.ToLowerInvariant(str[0]) + str[1..];
    }

    public static DateTime ToDateTime(this string str, string format)
    {
        return DateTime.SpecifyKind(DateTime.ParseExact(str, format, CultureInfo.InvariantCulture), DateTimeKind.Utc);
    }

    public static string ToStringHour(this string str)
    {
        return str
            .Insert(2, ":")
            .Insert(5, ":");
    }

    public static decimal ToFixedDecimal(this string str)
    {
        return Convert.ToDecimal(str) / 100;
    }

    public static T ToEnum<T>(this string str)
    {
        return (T)Enum.Parse(typeof(T), str);
    }
}