using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    public class StringToPathConverter : ChainConverter<string, Path>
    {
        #region Ctor

        public StringToPathConverter()
        {
            Height = 12;
            Width = 12;
            Stretch = Stretch.Fill;
            Foreground = Brushes.Black;
        }

        #endregion

        #region Properties

        public Brush Foreground { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public Stretch Stretch { get; set; }

        #endregion

        #region Overridden members

        protected override Path Convert(string value, Type targetType, object parameter, Culture culture)
        {
            if (value == null)
                return null;

            try
            {
                var geometry = Geometry.Parse(value);
                return new Path
                {
                    Data = geometry,
                    Height = Height,
                    Width = Height,
                    IsHitTestVisible = false,
                    Stretch = Stretch,
                    Fill = Foreground,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected override string ConvertBack(Path value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
