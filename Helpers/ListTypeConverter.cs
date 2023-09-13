using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace Geocode.Helpers
{
    public class ListTypeConverter<T> : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return text.Split('|').ToList();
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return string.Join("|", ((List<T>)value).Select(item => item.ToString()));
        }
    }
}
