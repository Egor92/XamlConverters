#if WPF
using System.Windows;
#elif WINDOWS_UWP
using Windows.UI.Xaml;

#endif

namespace Egor92.XamlConverters
{
    public class BoolToVisibilityConverter : BoolConverterBase<Visibility>
    {
        protected override Visibility GetDefaultTrueValue()
        {
            return Visibility.Visible;
        }

        protected override Visibility GetDefaultFalseValue()
        {
            return Visibility.Collapsed;
        }
    }
}
