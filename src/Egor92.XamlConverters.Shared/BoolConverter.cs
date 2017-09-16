namespace Egor92.XamlConverters
{
    public class BoolConverter : BoolConverterBase<object>
    {
        protected override object GetDefaultTrueValue()
        {
            return null;
        }

        protected override object GetDefaultFalseValue()
        {
            return null;
        }
    }
}
