using System;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class IsNullConverter : ChainConverter<object, bool>
    {
        protected override bool Convert(object value, Type targetType, object parameter, Culture culture)
        {
            return value == null;
        }

        protected override object ConvertBack(bool value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }
    }
}
