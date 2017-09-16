using System;
using System.Collections.Generic;
using System.Windows.Markup;
using Egor92.XamlConverters.Cases;
#if WPF
using Culture = System.Globalization.CultureInfo;

#elif WINDOWS_UWP
using Culture = System.String;

#endif

namespace Egor92.XamlConverters
{
    [ContentProperty("Cases")]
    public class SwitchConverter : ChainConverter<object, object>
    {
        public List<ICase> Cases { get; } = new List<ICase>();

        public object Default { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, Culture culture)
        {
            foreach (var @case in Cases)
            {
                if (@case.IsMatched(value))
                    return @case.Value;
            }
            return Default;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, Culture culture)
        {
            throw new NotSupportedException();
        }
    }
}