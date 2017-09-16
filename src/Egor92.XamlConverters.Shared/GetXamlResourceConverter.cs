using System;
using System.Windows;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class GetXamlResourceConverter : ChainConverter<object, object>
    {
        public FrameworkElement ResourceOwner { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, Culture culture)
        {
            if (value == null)
                return null;

            var resources = ResourceOwner?.Resources ?? Application.Current.Resources;

            if (!resources.Contains(value))
                return null;
            return resources[value];
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }
    }
}
