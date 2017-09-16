using System;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class InvertBoolConverter : ChainConverter<bool,bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, Culture culture)
        {
            return !value;
        }

        protected override bool ConvertBack(bool value, Type targetType, object parameter, Culture culture)
        {
            return !value;
        }
    }

}
