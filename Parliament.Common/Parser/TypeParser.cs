using System;
using System.ComponentModel;
using System.Globalization;
using Parliament.Common.Extensions;

namespace Parliament.Common.Parser
{
    public class TypeParser
    {
        public static T? Parse<T>(string input) where T : struct
        {
            if (String.IsNullOrEmpty(input)) return null;
            var type = typeof (T);            
            var converter = TypeDescriptor.GetConverter(type);
            if (converter == null) throw new InvalidOperationException("The type '{0}' is not supported for Parsing".FormatString(type.AssemblyQualifiedName));
            try
            {
                return (T?)converter.ConvertFromString(null, CultureInfo.InvariantCulture, input);            
            }
            catch (Exception)
            {
                return null;                
            }            
        }


        /// <summary>
        /// Use ParseDirect when you are certain that no value that will be given to you will not be parseable. Use at your own risk!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T ParseDirect<T>(string input) where T : struct
        {
            var result = Parse<T>(input);
            if (!result.HasValue) throw new InvalidOperationException("TypeParser could not parse the input '{0}' as type '{1}'. If you are in doubt of the quality of data or could potentially recieve a value that would not parse to this type, use Parse instead of ParseDirect");
            return result.Value;
        }

        public static DateTime? ParseExactDateTime(string input, string dateFormat)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)
                        ? dateTime
                        : (DateTime?)null;
        }

        public static T? ParseEnum<T>(string value) where T : struct
        {
            if (String.IsNullOrEmpty(value)) return null;
            T result;
            var canParse = Enum.TryParse(value, true, out result);
            return canParse ? (T?)result : null;
        }
    }
}
