using System;
using System.Windows.Media;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class StringToBrushConverter : ChainConverter<string, SolidColorBrush>
    {
        #region Fields

        private readonly BrushConverter _brushConverter = new BrushConverter();

        #endregion

        #region Overridden members

        protected override SolidColorBrush Convert(string value, Type targetType, object parameter, Culture culture)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            try
            {
                return (SolidColorBrush)_brushConverter.ConvertFrom(value);
            }
            catch
            {
                return null;
            }
        }

        protected override string ConvertBack(SolidColorBrush value, Type targetType, object parameter, Culture culture)
        {
            return value?.Color.ToString();
        }

        #endregion
    }
}
