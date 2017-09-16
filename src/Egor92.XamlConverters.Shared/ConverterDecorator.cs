using System;
#if WPF
using System.Windows.Markup;
using System.Windows.Data;
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
#if WPF
    [ContentProperty("NextConverter")]
    public abstract class ConverterDecorator : MarkupExtension, IValueConverter
#elif WINDOWS_UWP
    [ContentProperty(Name = "NextConverter")]
    public abstract class ConverterDecorator : IValueConverter
#endif
    {
        public IValueConverter NextConverter { get; set; }

        public IValueConverter DecoratedConverter { get; set; }

        object IValueConverter.Convert(object value, Type targetType, object parameter, Culture culture)
        {
            if (DecoratedConverter != null)
                value = DecoratedConverter.Convert(value, targetType, parameter, culture);
            if (NextConverter != null)
                value = NextConverter.Convert(value, targetType, parameter, culture);
            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, Culture culture)
        {
            if (DecoratedConverter != null)
                value = DecoratedConverter.ConvertBack(value, targetType, parameter, culture);
            if (NextConverter != null)
                value = NextConverter.ConvertBack(value, targetType, parameter, culture);
            return value;
        }

#if WPF
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
#endif
    }
}
