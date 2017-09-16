using System;
#if WPF
using System.Windows.Markup;
using System.Windows;
using System.Windows.Data;
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
#if WPF
    [ContentProperty("NextConverter")]
    public abstract class ChainConverter<TFrom, TTo> : MarkupExtension, IValueConverter
#elif WINDOWS_UWP
    [ContentProperty(Name = "NextConverter")]
    public abstract class ChainConverter<TFrom, TTo> : IValueConverter
#endif
    {
        public IValueConverter NextConverter { get; set; }

        object IValueConverter.Convert(object value, Type targetType, object parameter, Culture culture)
        {
            if (value == DependencyProperty.UnsetValue)
                return DependencyProperty.UnsetValue;

            var castedValue = (TFrom) value;
            object convertedValue = Convert(castedValue, targetType, parameter, culture);
            object result = convertedValue;
            if (NextConverter != null)
                result = NextConverter.Convert(convertedValue, targetType, parameter, culture);
            return result;
        }

        protected abstract TTo Convert(TFrom value, Type targetType, object parameter, Culture culture);

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, Culture culture)
        {
            if (value == DependencyProperty.UnsetValue)
                return DependencyProperty.UnsetValue;

            var castedValue = (TTo) value;
            object convertedValue = ConvertBack(castedValue, targetType, parameter, culture);
            object result = convertedValue;
            if (NextConverter != null)
                result = NextConverter.ConvertBack(convertedValue, targetType, parameter, culture);
            return result;
        }

        protected abstract TFrom ConvertBack(TTo value, Type targetType, object parameter, Culture culture);

#if WPF
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
#endif
    }
}
