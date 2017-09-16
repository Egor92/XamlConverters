namespace Egor92.XamlConverters.Cases
{
    public class EqualsCase : ICase
    {
        public object Key { get; set; }

        public object Value { get; set; }

        public bool IsMatched(object value)
        {
            return Equals(value, Key);
        }
    }
}
