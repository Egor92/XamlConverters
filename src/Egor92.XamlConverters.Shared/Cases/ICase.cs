namespace Egor92.XamlConverters.Cases
{
    public interface ICase
    {
        bool IsMatched(object value);
        object Value { get; }
    }
}