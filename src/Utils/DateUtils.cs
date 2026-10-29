using System.Globalization;

namespace MultimediaCatalog.src.Utils;

public static class DateUtils
{
    public static string FormatPublicationDate(DateTime date)
    {
        var formattedDate = date.ToString("d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));

        return $"Estrenada el {formattedDate}";
    }

    public static DateTime ParseDate(string strDate)
    {
        if (!DateTime.TryParse(strDate, out var date)) return DateTime.MinValue;

        return date;
    } 
}