using System;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class EqualsValueConverter : ChainConverter<object, bool>
    {
        public object Value { get; set; }

        protected override bool Convert(object value, Type targetType, object parameter, Culture culture)
        {
            if (Value == null && value == null)
                return true;

            return Equals(Value, value);
        }

        protected override object ConvertBack(bool value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }
    }
}
