using System;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class ObjectToStringConverter : ChainConverter<object, string>
    {
        private const string DefaultFormat = @"{0}";

        public string StringFormat { get; set; }

        public string ValueFormat { get; set; }

        public string NullValueRepresentation { get; set; }

        protected override string Convert(object value, Type targetType, object parameter, Culture culture)
        {
            string valueAsString;
            if (value == null)
            {
                valueAsString = NullValueRepresentation;
            }
            else
            {
                string valueFormat = GetValueFormat();
                valueAsString = string.Format(valueFormat, value);
            }
            StringFormat = StringFormat ?? DefaultFormat;
            return string.Format(StringFormat, valueAsString);
        }

        protected override object ConvertBack(string value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }

        private string GetValueFormat()
        {
            if (ValueFormat == null)
                return DefaultFormat;
            return $@"{{0:{ValueFormat}}}";
        }
    }
}
