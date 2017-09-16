using System;
using System.ComponentModel;
using System.Linq;
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
    public class EnumToDescriptionConverter : ChainConverter<object, string>
    {
        protected override string Convert(object value, Type targetType, object parameter, Culture culture)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return string.Empty;

            var description = GetDescription((Enum) value);
            return description;
        }

        protected override object ConvertBack(string value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }

        private static string GetDescription(Enum enumObj)
        {
            var fieldInfo = enumObj.GetType()
                                   .GetField(enumObj.ToString());
            if (fieldInfo == null)
                return string.Empty;

            var descriptionAttribute = (DescriptionAttribute) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                                       .FirstOrDefault();
            if (descriptionAttribute == null)
                return enumObj.ToString();

            return descriptionAttribute.Description;
        }
    }
}
