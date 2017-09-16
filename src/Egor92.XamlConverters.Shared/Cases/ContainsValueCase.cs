using System.Collections.Generic;
using System.Linq;
#if WPF
using System.Windows.Markup;
#elif WINDOWS_UWP
using Windows.UI.Xaml.Markup;

#endif

namespace Egor92.XamlConverters.Cases
{
    [ContentProperty("Keys")]
    public class ContainsValueCase : ICase
    {
        public List<object> Keys { get; } = new List<object>();

        public object Value { get; set; }

        public bool IsMatched(object value)
        {
            return Keys.Any(key => Equals(key, value));
        }
    }
}
